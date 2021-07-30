
namespace Heic2Whatever
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxResizeIfLargerThan = new System.Windows.Forms.CheckBox();
            this.groupBoxResizeRules = new System.Windows.Forms.GroupBox();
            this.textBoxResizetoExactSizeHeight = new System.Windows.Forms.TextBox();
            this.textBoxResizetoExactSizeWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxResizeByPercentage = new System.Windows.Forms.TextBox();
            this.radioButtonResizetoExactSize = new System.Windows.Forms.RadioButton();
            this.radioButtonResizeByPercentage = new System.Windows.Forms.RadioButton();
            this.textBoxResizeIfLargerThanHeight = new System.Windows.Forms.TextBox();
            this.textBoxResizeIfLargerThanWidth = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCPUThreads = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxOtherOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxResizeRules.SuspendLayout();
            this.groupBoxOtherOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(415, 183);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(334, 183);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxResizeIfLargerThan
            // 
            this.checkBoxResizeIfLargerThan.AutoSize = true;
            this.checkBoxResizeIfLargerThan.Location = new System.Drawing.Point(8, 40);
            this.checkBoxResizeIfLargerThan.Name = "checkBoxResizeIfLargerThan";
            this.checkBoxResizeIfLargerThan.Size = new System.Drawing.Size(128, 19);
            this.checkBoxResizeIfLargerThan.TabIndex = 8;
            this.checkBoxResizeIfLargerThan.Text = "Resize if larger than";
            this.checkBoxResizeIfLargerThan.UseVisualStyleBackColor = true;
            this.checkBoxResizeIfLargerThan.CheckedChanged += new System.EventHandler(this.checkBoxResizeIfLargerThan_CheckedChanged);
            // 
            // groupBoxResizeRules
            // 
            this.groupBoxResizeRules.Controls.Add(this.label1);
            this.groupBoxResizeRules.Controls.Add(this.textBoxResizetoExactSizeHeight);
            this.groupBoxResizeRules.Controls.Add(this.textBoxResizetoExactSizeWidth);
            this.groupBoxResizeRules.Controls.Add(this.label2);
            this.groupBoxResizeRules.Controls.Add(this.textBoxResizeByPercentage);
            this.groupBoxResizeRules.Controls.Add(this.radioButtonResizetoExactSize);
            this.groupBoxResizeRules.Controls.Add(this.radioButtonResizeByPercentage);
            this.groupBoxResizeRules.Controls.Add(this.textBoxResizeIfLargerThanHeight);
            this.groupBoxResizeRules.Controls.Add(this.textBoxResizeIfLargerThanWidth);
            this.groupBoxResizeRules.Controls.Add(this.checkBoxResizeIfLargerThan);
            this.groupBoxResizeRules.Controls.Add(this.labelX);
            this.groupBoxResizeRules.Controls.Add(this.labelWidth);
            this.groupBoxResizeRules.Controls.Add(this.labelHeight);
            this.groupBoxResizeRules.Location = new System.Drawing.Point(12, 12);
            this.groupBoxResizeRules.Name = "groupBoxResizeRules";
            this.groupBoxResizeRules.Size = new System.Drawing.Size(272, 147);
            this.groupBoxResizeRules.TabIndex = 9;
            this.groupBoxResizeRules.TabStop = false;
            this.groupBoxResizeRules.Text = "Resize Rules";
            // 
            // textBoxResizetoExactSizeHeight
            // 
            this.textBoxResizetoExactSizeHeight.Location = new System.Drawing.Point(212, 69);
            this.textBoxResizetoExactSizeHeight.Name = "textBoxResizetoExactSizeHeight";
            this.textBoxResizetoExactSizeHeight.Size = new System.Drawing.Size(40, 23);
            this.textBoxResizetoExactSizeHeight.TabIndex = 23;
            // 
            // textBoxResizetoExactSizeWidth
            // 
            this.textBoxResizetoExactSizeWidth.Location = new System.Drawing.Point(147, 69);
            this.textBoxResizetoExactSizeWidth.Name = "textBoxResizetoExactSizeWidth";
            this.textBoxResizetoExactSizeWidth.Size = new System.Drawing.Size(40, 23);
            this.textBoxResizetoExactSizeWidth.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "x";
            // 
            // textBoxResizeByPercentage
            // 
            this.textBoxResizeByPercentage.Location = new System.Drawing.Point(155, 102);
            this.textBoxResizeByPercentage.Name = "textBoxResizeByPercentage";
            this.textBoxResizeByPercentage.Size = new System.Drawing.Size(40, 23);
            this.textBoxResizeByPercentage.TabIndex = 19;
            // 
            // radioButtonResizetoExactSize
            // 
            this.radioButtonResizetoExactSize.AutoSize = true;
            this.radioButtonResizetoExactSize.Location = new System.Drawing.Point(8, 70);
            this.radioButtonResizetoExactSize.Name = "radioButtonResizetoExactSize";
            this.radioButtonResizetoExactSize.Size = new System.Drawing.Size(125, 19);
            this.radioButtonResizetoExactSize.TabIndex = 16;
            this.radioButtonResizetoExactSize.TabStop = true;
            this.radioButtonResizetoExactSize.Text = "Resize to Exact Size";
            this.radioButtonResizetoExactSize.UseVisualStyleBackColor = true;
            this.radioButtonResizetoExactSize.CheckedChanged += new System.EventHandler(this.radioButtonResizetoExactSize_CheckedChanged);
            // 
            // radioButtonResizeByPercentage
            // 
            this.radioButtonResizeByPercentage.AutoSize = true;
            this.radioButtonResizeByPercentage.Location = new System.Drawing.Point(8, 102);
            this.radioButtonResizeByPercentage.Name = "radioButtonResizeByPercentage";
            this.radioButtonResizeByPercentage.Size = new System.Drawing.Size(133, 19);
            this.radioButtonResizeByPercentage.TabIndex = 15;
            this.radioButtonResizeByPercentage.TabStop = true;
            this.radioButtonResizeByPercentage.Text = "Resize to Percentage";
            this.radioButtonResizeByPercentage.UseVisualStyleBackColor = true;
            this.radioButtonResizeByPercentage.CheckedChanged += new System.EventHandler(this.radioButtonResizeByPercentage_CheckedChanged);
            // 
            // textBoxResizeIfLargerThanHeight
            // 
            this.textBoxResizeIfLargerThanHeight.Location = new System.Drawing.Point(212, 37);
            this.textBoxResizeIfLargerThanHeight.Name = "textBoxResizeIfLargerThanHeight";
            this.textBoxResizeIfLargerThanHeight.Size = new System.Drawing.Size(40, 23);
            this.textBoxResizeIfLargerThanHeight.TabIndex = 14;
            // 
            // textBoxResizeIfLargerThanWidth
            // 
            this.textBoxResizeIfLargerThanWidth.Location = new System.Drawing.Point(147, 37);
            this.textBoxResizeIfLargerThanWidth.Name = "textBoxResizeIfLargerThanWidth";
            this.textBoxResizeIfLargerThanWidth.Size = new System.Drawing.Size(40, 23);
            this.textBoxResizeIfLargerThanWidth.TabIndex = 13;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(193, 40);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 15);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "x";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(148, 19);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(39, 15);
            this.labelWidth.TabIndex = 10;
            this.labelWidth.Text = "Width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(209, 19);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(43, 15);
            this.labelHeight.TabIndex = 11;
            this.labelHeight.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "%";
            // 
            // textBoxCPUThreads
            // 
            this.textBoxCPUThreads.Location = new System.Drawing.Point(86, 22);
            this.textBoxCPUThreads.Name = "textBoxCPUThreads";
            this.textBoxCPUThreads.Size = new System.Drawing.Size(40, 23);
            this.textBoxCPUThreads.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "CPU Threads";
            // 
            // groupBoxOtherOptions
            // 
            this.groupBoxOtherOptions.Controls.Add(this.textBoxCPUThreads);
            this.groupBoxOtherOptions.Controls.Add(this.label3);
            this.groupBoxOtherOptions.Location = new System.Drawing.Point(290, 12);
            this.groupBoxOtherOptions.Name = "groupBoxOtherOptions";
            this.groupBoxOtherOptions.Size = new System.Drawing.Size(200, 100);
            this.groupBoxOtherOptions.TabIndex = 27;
            this.groupBoxOtherOptions.TabStop = false;
            this.groupBoxOtherOptions.Text = "Other Options";
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 230);
            this.Controls.Add(this.groupBoxOtherOptions);
            this.Controls.Add(this.groupBoxResizeRules);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.groupBoxResizeRules.ResumeLayout(false);
            this.groupBoxResizeRules.PerformLayout();
            this.groupBoxOtherOptions.ResumeLayout(false);
            this.groupBoxOtherOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxResizeIfLargerThan;
        private System.Windows.Forms.GroupBox groupBoxResizeRules;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textBoxResizeIfLargerThanHeight;
        private System.Windows.Forms.TextBox textBoxResizeIfLargerThanWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxResizetoExactSizeHeight;
        private System.Windows.Forms.TextBox textBoxResizetoExactSizeWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxResizeByPercentage;
        private System.Windows.Forms.RadioButton radioButtonResizetoExactSize;
        private System.Windows.Forms.RadioButton radioButtonResizeByPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCPUThreads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxOtherOptions;
    }
}