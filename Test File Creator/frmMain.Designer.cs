namespace Test_File_Creator
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            cboTextGenerator = new ComboBox();
            lblTextGenerator = new Label();
            progressBar = new ProgressBar();
            btnClearLog = new Button();
            nudFileNameWordCount = new NumericUpDown();
            lblFileNameWordCount = new Label();
            lblLog = new Label();
            txtLog = new TextBox();
            nudFileSizeMax = new NumericUpDown();
            nudFileSizeMin = new NumericUpDown();
            nudFileCount = new NumericUpDown();
            cboFileSizeMax = new ComboBox();
            lblFileSizeMax = new Label();
            cboFileSizeMin = new ComboBox();
            btnBrowse = new Button();
            btnGenerate = new Button();
            lblPath = new Label();
            txtFilePath = new TextBox();
            lblFileSizeMin = new Label();
            lblFileCount = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolstrip_File_Exit = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolstrip_Help_About = new ToolStripMenuItem();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFileNameWordCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFileSizeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFileSizeMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFileCount).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(cboTextGenerator);
            pnlMain.Controls.Add(lblTextGenerator);
            pnlMain.Controls.Add(progressBar);
            pnlMain.Controls.Add(btnClearLog);
            pnlMain.Controls.Add(nudFileNameWordCount);
            pnlMain.Controls.Add(lblFileNameWordCount);
            pnlMain.Controls.Add(lblLog);
            pnlMain.Controls.Add(txtLog);
            pnlMain.Controls.Add(nudFileSizeMax);
            pnlMain.Controls.Add(nudFileSizeMin);
            pnlMain.Controls.Add(nudFileCount);
            pnlMain.Controls.Add(cboFileSizeMax);
            pnlMain.Controls.Add(lblFileSizeMax);
            pnlMain.Controls.Add(cboFileSizeMin);
            pnlMain.Controls.Add(btnBrowse);
            pnlMain.Controls.Add(btnGenerate);
            pnlMain.Controls.Add(lblPath);
            pnlMain.Controls.Add(txtFilePath);
            pnlMain.Controls.Add(lblFileSizeMin);
            pnlMain.Controls.Add(lblFileCount);
            pnlMain.Location = new Point(12, 27);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(776, 411);
            pnlMain.TabIndex = 0;
            // 
            // cboTextGenerator
            // 
            cboTextGenerator.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTextGenerator.FormattingEnabled = true;
            cboTextGenerator.Items.AddRange(new object[] { "LipsumGenerator", "Faker.net" });
            cboTextGenerator.Location = new Point(325, 14);
            cboTextGenerator.Name = "cboTextGenerator";
            cboTextGenerator.Size = new Size(141, 23);
            cboTextGenerator.TabIndex = 23;
            // 
            // lblTextGenerator
            // 
            lblTextGenerator.AutoSize = true;
            lblTextGenerator.Location = new Point(233, 16);
            lblTextGenerator.Name = "lblTextGenerator";
            lblTextGenerator.Size = new Size(86, 15);
            lblTextGenerator.TabIndex = 22;
            lblTextGenerator.Text = "Text Generator:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(93, 383);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(587, 23);
            progressBar.TabIndex = 21;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(14, 383);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(75, 23);
            btnClearLog.TabIndex = 20;
            btnClearLog.Text = "Clear";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // nudFileNameWordCount
            // 
            nudFileNameWordCount.Location = new Point(115, 46);
            nudFileNameWordCount.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nudFileNameWordCount.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            nudFileNameWordCount.Name = "nudFileNameWordCount";
            nudFileNameWordCount.Size = new Size(100, 23);
            nudFileNameWordCount.TabIndex = 19;
            nudFileNameWordCount.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblFileNameWordCount
            // 
            lblFileNameWordCount.AutoSize = true;
            lblFileNameWordCount.Location = new Point(14, 48);
            lblFileNameWordCount.Name = "lblFileNameWordCount";
            lblFileNameWordCount.Size = new Size(95, 15);
            lblFileNameWordCount.TabIndex = 17;
            lblFileNameWordCount.Text = "Filename Words:";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(14, 115);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(30, 15);
            lblLog.TabIndex = 16;
            lblLog.Text = "Log:";
            // 
            // txtLog
            // 
            txtLog.BackColor = SystemColors.ControlLightLight;
            txtLog.Location = new Point(14, 133);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(747, 244);
            txtLog.TabIndex = 15;
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // nudFileSizeMax
            // 
            nudFileSizeMax.Enabled = false;
            nudFileSizeMax.Location = new Point(567, 43);
            nudFileSizeMax.Maximum = new decimal(new int[] { int.MinValue, 2, 0, 0 });
            nudFileSizeMax.Name = "nudFileSizeMax";
            nudFileSizeMax.Size = new Size(100, 23);
            nudFileSizeMax.TabIndex = 14;
            nudFileSizeMax.Value = new decimal(new int[] { 10240, 0, 0, 0 });
            nudFileSizeMax.Visible = false;
            // 
            // nudFileSizeMin
            // 
            nudFileSizeMin.Enabled = false;
            nudFileSizeMin.Location = new Point(567, 14);
            nudFileSizeMin.Maximum = new decimal(new int[] { int.MinValue, 2, 0, 0 });
            nudFileSizeMin.Name = "nudFileSizeMin";
            nudFileSizeMin.Size = new Size(100, 23);
            nudFileSizeMin.TabIndex = 13;
            nudFileSizeMin.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudFileSizeMin.Visible = false;
            // 
            // nudFileCount
            // 
            nudFileCount.Location = new Point(115, 14);
            nudFileCount.Maximum = new decimal(new int[] { 50001, 0, 0, 0 });
            nudFileCount.Name = "nudFileCount";
            nudFileCount.Size = new Size(100, 23);
            nudFileCount.TabIndex = 12;
            nudFileCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboFileSizeMax
            // 
            cboFileSizeMax.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFileSizeMax.Enabled = false;
            cboFileSizeMax.FormattingEnabled = true;
            cboFileSizeMax.Items.AddRange(new object[] { "Bytes", "Kilobytes", "Megabytes", "Gigabytes" });
            cboFileSizeMax.Location = new Point(673, 43);
            cboFileSizeMax.Name = "cboFileSizeMax";
            cboFileSizeMax.Size = new Size(85, 23);
            cboFileSizeMax.TabIndex = 11;
            cboFileSizeMax.Visible = false;
            // 
            // lblFileSizeMax
            // 
            lblFileSizeMax.AutoSize = true;
            lblFileSizeMax.Location = new Point(488, 46);
            lblFileSizeMax.Name = "lblFileSizeMax";
            lblFileSizeMax.Size = new Size(77, 15);
            lblFileSizeMax.TabIndex = 10;
            lblFileSizeMax.Text = "Max File Size:";
            lblFileSizeMax.Visible = false;
            // 
            // cboFileSizeMin
            // 
            cboFileSizeMin.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFileSizeMin.Enabled = false;
            cboFileSizeMin.FormattingEnabled = true;
            cboFileSizeMin.Items.AddRange(new object[] { "Bytes", "Kilobytes", "Megabytes", "Gigabytes" });
            cboFileSizeMin.Location = new Point(673, 14);
            cboFileSizeMin.Name = "cboFileSizeMin";
            cboFileSizeMin.Size = new Size(85, 23);
            cboFileSizeMin.TabIndex = 8;
            cboFileSizeMin.Visible = false;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(729, 75);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(29, 23);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(686, 383);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(14, 79);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(96, 15);
            lblPath.TabIndex = 5;
            lblPath.Text = "File Output Path:";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(115, 76);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(611, 23);
            txtFilePath.TabIndex = 4;
            // 
            // lblFileSizeMin
            // 
            lblFileSizeMin.AutoSize = true;
            lblFileSizeMin.Location = new Point(488, 17);
            lblFileSizeMin.Name = "lblFileSizeMin";
            lblFileSizeMin.Size = new Size(75, 15);
            lblFileSizeMin.TabIndex = 3;
            lblFileSizeMin.Text = "Min File Size:";
            lblFileSizeMin.Visible = false;
            // 
            // lblFileCount
            // 
            lblFileCount.AutoSize = true;
            lblFileCount.Location = new Point(14, 16);
            lblFileCount.Name = "lblFileCount";
            lblFileCount.Size = new Size(64, 15);
            lblFileCount.TabIndex = 1;
            lblFileCount.Text = "File Count:";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolstrip_File_Exit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // toolstrip_File_Exit
            // 
            toolstrip_File_Exit.Name = "toolstrip_File_Exit";
            toolstrip_File_Exit.Size = new Size(93, 22);
            toolstrip_File_Exit.Text = "E&xit";
            toolstrip_File_Exit.Click += toolstrip_File_Exit_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolstrip_Help_About });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // toolstrip_Help_About
            // 
            toolstrip_Help_About.Name = "toolstrip_Help_About";
            toolstrip_Help_About.Size = new Size(116, 22);
            toolstrip_Help_About.Text = "&About...";
            toolstrip_Help_About.Click += toolstrip_Help_About_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlMain);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test File Creator";
            FormClosing += frmMain_FormClosing;
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFileNameWordCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFileSizeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFileSizeMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFileCount).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMain;
        private Button btnGenerate;
        private Label lblPath;
        private TextBox txtFilePath;
        private Label lblFileSizeMin;
        private Label lblFileCount;
        private FolderBrowserDialog folderBrowserDialog;
        private Button btnBrowse;
        private ComboBox cboFileSizeMin;
        private ComboBox cboFileSizeMax;
        private Label lblFileSizeMax;
        private NumericUpDown nudFileCount;
        private NumericUpDown nudFileSizeMax;
        private NumericUpDown nudFileSizeMin;
        private Label lblLog;
        private TextBox txtLog;
        private NumericUpDown nudFileNameWordCount;
        private Label lblFileNameWordCount;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolstrip_Help_About;
        private ToolStripMenuItem toolstrip_File_Exit;
        private Button btnClearLog;
        private ProgressBar progressBar;
        private ComboBox cboTextGenerator;
        private Label lblTextGenerator;
    }
}