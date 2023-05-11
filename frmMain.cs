using NLipsum.Core.Features;
using System.IO;
using System.Text;

namespace Test_File_Creator
{
    public partial class frmMain : Form
    {
        #region Initialization

        public frmMain()
        {
            InitializeComponent();

            // Defaults
            cboFileSizeMin.SelectedIndex = 0;
            cboFileSizeMax.SelectedIndex = 0;
            txtFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Load Settings
            nudFileCount.Value = (int)Properties.Settings.Default["FileCount"];
            nudFileSizeMin.Value = (long)Properties.Settings.Default["FileSizeMin"];
            nudFileSizeMax.Value = (long)Properties.Settings.Default["FileSizeMax"];
            nudFileNameWordCount.Value = (int)Properties.Settings.Default["FilenameWordCount"];
            txtFilePath.Text = Properties.Settings.Default["FilePath"].ToString() != String.Empty ? Properties.Settings.Default["FilePath"].ToString() : txtFilePath.Text;
        }

        #endregion

        #region Methods

        private void CreateFiles(ref int intFilesCreated)
        {
            try
            {
                var lgen = new NLipsum.Core.LipsumGenerator();

                string strFileName = String.Empty;
                StringBuilder sbFileName = new StringBuilder();

                for (int i = 0; i <= nudFileNameWordCount.Value; i++)
                {
                    string newWord = lgen.RandomWord();
                    newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1);
                    sbFileName.Append(newWord);
                    if (i != nudFileNameWordCount.Value) sbFileName.Append(" ");
                }
                sbFileName.Append(".txt");
                strFileName = sbFileName.ToString();

                string strPath = txtFilePath.Text + "\\" + strFileName;

                if (!File.Exists(strPath))
                {
                    using (FileStream fs = File.Create(strPath))
                    {
                        // Todo: Figure out a better way to predict how many paragraphs we need
                        //      10 = roughly 7kb
                        //     100 = roughly 68-76kb
                        var strFileContents = lgen.GenerateParagraphs(10, Paragraph.Medium);

                        byte[] info = new UTF8Encoding(true).GetBytes(String.Join(Environment.NewLine, strFileContents));

                        fs.Write(info, 0, info.Length);

                        txtLog.Text += Environment.NewLine + "Created file '" + strFileName + "' with " + info.Length + " bytes";

                        intFilesCreated++;
                    }
                }
                else
                {
                    txtLog.Text += Environment.NewLine + "Error creating file, file already exists.  File name: " + strFileName;
                }
            }
            catch (Exception ex)
            {
                txtLog.Text += Environment.NewLine + "Error creating file " + ex.ToString();
            }
        }

        private void SaveSettings()
        {
            Properties.Settings.Default["FileCount"] = (int)nudFileCount.Value;
            Properties.Settings.Default["FileSizeMin"] = (long)nudFileSizeMin.Value;
            Properties.Settings.Default["FileSizeMax"] = (long)nudFileSizeMax.Value;
            Properties.Settings.Default["FilenameWordCount"] = (int)nudFileNameWordCount.Value;
            Properties.Settings.Default["FilePath"] = txtFilePath.Text;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Form Events

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.InitialDirectory = txtFilePath.Text;
            DialogResult drFolder = folderBrowserDialog.ShowDialog(this);
            if (drFolder == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int intFilesCreated = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = (int)nudFileCount.Value;

            txtLog.Text = "Starting to generate " + nudFileCount.Value + " files at " + txtFilePath.Text + Environment.NewLine;
            for (int i = 0; i < nudFileCount.Value; i++)
            {
                // Todo: Breakout filename generation, content creation, and file creation into separate methods
                CreateFiles(ref intFilesCreated);

                Application.DoEvents();
                progressBar.Value = i;
            }
            progressBar.Value = (int)nudFileCount.Value;

            txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
        }

        private void toolstrip_File_Exit_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Application.Exit();
        }

        private void toolstrip_Help_About_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = String.Empty;
            progressBar.Value = 0;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        #endregion
    }
}