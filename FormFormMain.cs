using ImageMagick;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Heic2Whatever
{
    public partial class FormFormMain : Form
    {
        private const int StatusColumnIndex = 3;
        private ConcurrentQueue<QueueItem> _queue = null;
        private volatile int _activeThreadCount = 0;
        private bool _cancel = false;
        private bool _running = false;

        private OperatingParams _operateParam = new OperatingParams();

        private class QueueItem
        {
            public int RowIndex { get; set; }
            public FileInfo Info { get; set; }
        }

        class FormatSelection
        {
            public string Text { get; set; }
            public MagickFormat Value { get; set; }
        }

        public FormFormMain()
        {
            InitializeComponent();

            this.FormClosing += FormFormMain_FormClosing;

            comboBoxOutputFormat.ValueMember = "Value";
            comboBoxOutputFormat.DisplayMember = "Text";

            comboBoxOutputFormat.Items.Add(new FormatSelection { Text = "PNG", Value = MagickFormat.Png });
            comboBoxOutputFormat.Items.Add(new FormatSelection { Text = "JPG", Value = MagickFormat.Jpg });
            comboBoxOutputFormat.Items.Add(new FormatSelection { Text = "BMP", Value = MagickFormat.Bmp3 });

            comboBoxOutputFormat.Text = "JPG";

            _operateParam = OperatingParams.LoadFromRegistry();

            textBoxOutputPath.Text = _operateParam.OutputPath;

            foreach (FormatSelection item in comboBoxOutputFormat.Items)
            {
                if (item.Value == _operateParam.Format)
                {
                    comboBoxOutputFormat.SelectedItem = item;
                    break;
                }
            }
        }

        private void FormFormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_running && _cancel == false)
            {
                e.Cancel = true;

                if (MessageBox.Show("Are you sure you want to cancel the current operation?", "Cancel?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _cancel = true;
                    buttonGo.Text = "Stoping..";
                    buttonGo.Enabled = false;
                }
            }
        }

        private void SafeSetText(int rowIndex, string status)
        {
            if (listViewFiles.InvokeRequired)
            {
                listViewFiles.Invoke((MethodInvoker)delegate ()
                {
                    listViewFiles.Items[rowIndex].SubItems[StatusColumnIndex].Text = status;
                    listViewFiles.EnsureVisible(rowIndex);
                });
            }
            else
            {
                listViewFiles.Items[rowIndex].SubItems[StatusColumnIndex].Text = status;
                listViewFiles.EnsureVisible(rowIndex);
            }
        }

        private void WorkerThreadProc()
        {
            while (_queue.Count > 0 && _cancel == false)
            {
                QueueItem item;

                if (_queue.TryDequeue(out item))
                {
                    SafeSetText(item.RowIndex, "Processing.");

                    string outputFile = $"{Path.Combine(_operateParam.OutputPath, Path.GetFileNameWithoutExtension(item.Info.Name))}.{_operateParam.Extension}";

                    if (File.Exists(outputFile) && _operateParam.OverwriteExistingFiles == false)
                    {
                        SafeSetText(item.RowIndex, "Already exists.");
                    }
                    else
                    {
                        using (MagickImage image = new MagickImage(item.Info.FullName))
                        {
                            if (_operateParam.ResizeIfLargerThan)
                            {
                                if (image.Width > _operateParam.ResizeIfLargerThanWidth || image.Height > _operateParam.ResizeIfLargerThanHeight)
                                {
                                    if (_operateParam.ResizeToExactSize)
                                    {
                                        image.Resize(_operateParam.ResizeToExactSizeWidth, _operateParam.ResizeToExactSizeHeight);
                                    }
                                    else if (_operateParam.ResizeByPercentage)
                                    {
                                        image.Resize(new Percentage(_operateParam.ResizeByPercentageValue));
                                    }
                                }
                            }

                            image.Write(outputFile, _operateParam.Format);
                            SafeSetText(item.RowIndex, "Complete.");
                        }
                    }
                }
            }

            _activeThreadCount--;

            if (_activeThreadCount == 0)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.SwapAbility(true);
                    });
                }
                else
                {
                    SwapAbility(true);
                }

                _running = false;
            }
        }

        private void StartWorkers()
        {
            _cancel = false;
            _running = true;
            for (int i = 0; i < _operateParam.CPUThreadCount; i++)
            {
                _activeThreadCount++;
                (new Thread(WorkerThreadProc)).Start();
            }
        }

        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter =
                    "HEIC Images (*.HEIC)|*.HEIC;|All files (*.*)|*.*";
                ofd.Multiselect = true;
                ofd.Title = "Select Images";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in ofd.FileNames)
                    {
                        AddFileToListView(fileName);
                    }
                }
            }
        }

        void AddFileToListView(string fileName)
        {
            var info = new FileInfo(fileName);

            var item = new ListViewItem()
            {
                Tag = info
            };

            item.Text = Path.GetFileName(fileName);
            item.SubItems.Add(Path.GetFullPath(fileName));
            item.SubItems.Add(Formatters.FormatFileSize(info.Length));

            item.SubItems.Add("Queued.");

            listViewFiles.Items.Add(item);
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            var files = ((string[])e.Data.GetData(DataFormats.FileDrop))?.ToList();

            if (!files.Any())
            {
                return;
            }

            files.ForEach(o => AddFileToListView(o));
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFiles.SelectedItems)
            {
                if (item.Index > 0)
                {
                    int index = item.Index - 1;
                    listViewFiles.Items.RemoveAt(item.Index);
                    listViewFiles.Items.Insert(index, item);
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            for (int i = listViewFiles.SelectedItems.Count - 1; i > -1; i--)
            {
                ListViewItem item = listViewFiles.SelectedItems[i];

                if (item.Index < listViewFiles.Items.Count - 1)
                {
                    int index = item.Index + 1;
                    listViewFiles.Items.RemoveAt(item.Index);
                    listViewFiles.Items.Insert(index, item);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFiles.SelectedItems)
            {
                listViewFiles.Items.Remove(item);
            }
        }

        private void SwapAbility(bool able)
        {
            textBoxOutputPath.Enabled = able;
            buttonBrowseOutput.Enabled = able;
            comboBoxOutputFormat.Enabled = able;
            buttonAddFiles.Enabled = able;
            buttonMoveDown.Enabled = able;
            buttonMoveUp.Enabled = able;
            buttonRemove.Enabled = able;
            checkBoxOverwriteExistingFiles.Enabled = able;

            if (able == true)
            {
                buttonGo.BackColor = Color.FromArgb(128, 255, 128);
                buttonGo.Text = "Go!";
                buttonGo.Enabled = true;
            }
            else
            {
                buttonGo.BackColor = Color.FromArgb(255, 128, 128);
                buttonGo.Text = "Cancel";
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (buttonGo.Text == "Cancel")
            {
                if (MessageBox.Show("Are you sure you want to cancel the current operation?", "Cancel?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _cancel = true;
                    buttonGo.Text = "Stoping..";
                    buttonGo.Enabled = false;
                }
            }
            else if (buttonGo.Text == "Go!")
            {
                if (listViewFiles.Items.Count > 0)
                {
                    SwapAbility(false);

                    _queue = new ConcurrentQueue<QueueItem>();

                    _operateParam.OverwriteExistingFiles = checkBoxOverwriteExistingFiles.Checked;
                    _operateParam.OutputPath = textBoxOutputPath.Text;

                    if (comboBoxOutputFormat.Text == "PNG")
                    {
                        _operateParam.Format = MagickFormat.Png;
                        _operateParam.Extension = "png";
                    }
                    else if (comboBoxOutputFormat.Text == "JPG")
                    {
                        _operateParam.Format = MagickFormat.Jpg;
                        _operateParam.Extension = "jpg";
                    }
                    else if (comboBoxOutputFormat.Text == "BMP")
                    {
                        _operateParam.Format = MagickFormat.Bmp3;
                        _operateParam.Extension = "bmp";
                    }
                    else
                    {
                        _operateParam.Format = MagickFormat.Png;
                        _operateParam.Extension = "png";
                    }

                    OperatingParams.SaveToRegistry(_operateParam);

                    foreach (ListViewItem item in listViewFiles.Items)
                    {
                        item.SubItems[StatusColumnIndex].Text = "Queued.";

                        var info = item.Tag as FileInfo;

                        _queue.Enqueue(new QueueItem()
                        {
                            Info = info,
                            RowIndex = item.Index
                        });

                    }
                    StartWorkers();
                }
            }
        }

        private void buttonBrowseOutput_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = textBoxOutputPath.Text;
                    fbd.ShowNewFolderButton = true;
                    fbd.Description = "Select the directory where the output images will be saved.";
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        textBoxOutputPath.Text = fbd.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FormOptions(_operateParam))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _operateParam = dialog.OperateParam;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
