using System;
using System.Windows.Forms;

namespace Heic2Whatever
{
    public partial class FormOptions : Form
    {
        private bool _validationFailed = false;
        public OperatingParams OperateParam { get; set; }

        public FormOptions(OperatingParams operateParam)
        {
            InitializeComponent();
            OperateParam = operateParam;
        }

        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            this.AcceptButton = buttonOk;
            this.CancelButton = buttonCancel;

            checkBoxResizeIfLargerThan.Checked = OperateParam.ResizeIfLargerThan;
            textBoxResizeIfLargerThanWidth.Text = OperateParam.ResizeIfLargerThanWidth.ToString();
            textBoxResizeIfLargerThanHeight.Text = OperateParam.ResizeIfLargerThanHeight.ToString();

            radioButtonResizeByPercentage.Checked = OperateParam.ResizeByPercentage;
            textBoxResizeByPercentage.Text = OperateParam.ResizeByPercentageValue.ToString();

            radioButtonResizetoExactSize.Checked = OperateParam.ResizeToExactSize;
            textBoxResizetoExactSizeWidth.Text = OperateParam.ResizeToExactSizeWidth.ToString();
            textBoxResizetoExactSizeHeight.Text = OperateParam.ResizeToExactSizeHeight.ToString();

            textBoxCPUThreads.Text = OperateParam.CPUThreadCount.ToString();

            checkBoxResizeIfLargerThan_CheckedChanged(null, null);
        }

        private void checkBoxResizeIfLargerThan_CheckedChanged(object sender, EventArgs e)
        {
            bool able = checkBoxResizeIfLargerThan.Checked;

            textBoxResizeIfLargerThanWidth.Enabled = able;
            textBoxResizeIfLargerThanHeight.Enabled = able;

            radioButtonResizeByPercentage.Enabled = able;
            textBoxResizeByPercentage.Enabled = able && radioButtonResizeByPercentage.Checked;

            radioButtonResizetoExactSize.Enabled = able;
            textBoxResizetoExactSizeWidth.Enabled = able && radioButtonResizetoExactSize.Checked;
            textBoxResizetoExactSizeHeight.Enabled = able && radioButtonResizetoExactSize.Checked;

            if (radioButtonResizeByPercentage.Checked == false && radioButtonResizetoExactSize.Checked == false)
            {
                radioButtonResizeByPercentage.Checked = true;
            }
        }

        private void radioButtonResizeByPercentage_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxResizeIfLargerThan_CheckedChanged(null, null);
        }

        private void radioButtonResizetoExactSize_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxResizeIfLargerThan_CheckedChanged(null, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _validationFailed = false;

                OperateParam.CPUThreadCount = GetTextBoxInt(textBoxCPUThreads);
                if (OperateParam.CPUThreadCount <= 0 || OperateParam.CPUThreadCount > 128)
                {
                    MessageBox.Show("CPU Thread count is out of range (1-128)\r\n Wait... 128!?? ¯\\_(ツ)_/¯.", "Invalid entry.");
                    return;
                }

                OperateParam.ResizeIfLargerThan = checkBoxResizeIfLargerThan.Checked;
                if (OperateParam.ResizeIfLargerThan)
                {
                    OperateParam.ResizeIfLargerThanWidth = GetTextBoxInt(textBoxResizeIfLargerThanWidth);
                    OperateParam.ResizeIfLargerThanHeight = GetTextBoxInt(textBoxResizeIfLargerThanHeight);

                    if (OperateParam.ResizeIfLargerThanWidth < 0 || OperateParam.ResizeIfLargerThanHeight < 0)
                    {
                        MessageBox.Show("Resize by Percentage is out of range.", "Invalid entry.");
                        return;
                    }

                    OperateParam.ResizeByPercentage = radioButtonResizeByPercentage.Checked;
                    if (OperateParam.ResizeByPercentage)
                    {
                        OperateParam.ResizeByPercentageValue = GetTextBoxInt(textBoxResizeByPercentage);

                        if (OperateParam.ResizeByPercentageValue <= 0 || OperateParam.ResizeByPercentageValue > 100)
                        {
                            MessageBox.Show("Resize by Percentage is out of range.", "Invalid entry.");
                            return;
                        }
                    }

                    OperateParam.ResizeToExactSize = radioButtonResizetoExactSize.Checked;
                    if (OperateParam.ResizeToExactSize)
                    {
                        OperateParam.ResizeToExactSizeWidth = GetTextBoxInt(textBoxResizetoExactSizeWidth);
                        OperateParam.ResizeToExactSizeHeight = GetTextBoxInt(textBoxResizetoExactSizeHeight);

                        if (OperateParam.ResizeToExactSizeWidth <= 0 || OperateParam.ResizeToExactSizeHeight <= 0)
                        {
                            MessageBox.Show("Resize to Exact Size is out of range.", "Invalid entry.");
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("One or more of the values is invalid.", "Invalid entry.");
                _validationFailed = true;
            }

            if (_validationFailed == false)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        int GetTextBoxInt(TextBox control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                return 0;
            }

            int value;
            if (Int32.TryParse(control.Text.Trim(), out value))
            {
                return value;
            }

            MessageBox.Show($"The value of {control.Name} is invalid.", "Invalid entry.");

            _validationFailed = true;

            return 0;
        }

    }
}
