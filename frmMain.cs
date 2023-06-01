using NLipsum.Core;
using NLipsum.Core.Features;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Test_File_Creator
{
    public partial class frmMain : Form
    {
        #region Initialization

        Stopwatch swElapsed = new Stopwatch();

        public frmMain()
        {
            InitializeComponent();

            // Defaults
            lblElapsed.Text = String.Empty;
            cboFileSizeMin.SelectedIndex = 0;
            cboFileSizeMax.SelectedIndex = 0;
            cboTextGenerator.SelectedIndex = 0;
            txtFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.Text = Application.ProductName + " - v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            // Load Settings
            nudFileCount.Value = (int)Properties.Settings.Default["FileCount"];
            nudFileSizeMin.Value = (long)Properties.Settings.Default["FileSizeMin"];
            nudFileSizeMax.Value = (long)Properties.Settings.Default["FileSizeMax"];
            nudFileNameWordCount.Value = (int)Properties.Settings.Default["FilenameWordCount"];
            txtFilePath.Text = Properties.Settings.Default["FilePath"].ToString() != String.Empty ? Properties.Settings.Default["FilePath"].ToString() : txtFilePath.Text;
        }

        #endregion

        #region Methods

        public void CreateFiles(int intTextGenerator, int intFileCount, string strPath)
        {
            try
            {
                int intFilesCreated = 0;
                swElapsed.Start();
                timerElapsed.Start();
                progressBar.Minimum = 0;
                progressBar.Maximum = intFileCount;
                btnGenerate.Enabled = false;
                txtLog.Text = "Starting to generate " + intFileCount + " files at " + strPath + Environment.NewLine;

                for (int i = 0; i < intFileCount; i++)
                {
                    CreateFile(intTextGenerator, strPath, ref intFilesCreated);

                    Application.DoEvents();
                    progressBar.Value = i;
                }

                progressBar.Value = intFileCount;
                txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
                timerElapsed.Stop();
                swElapsed.Stop();
                txtLog.Text += Environment.NewLine + Environment.NewLine + "Elapsed time: " + swElapsed.Elapsed.ToString();
                btnGenerate.Enabled = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += Environment.NewLine + "Error creating file " + ex.ToString();
            }
        }

        // Todo: Split this method into smaller methods for unit testing
        // Params:
        //     intTextGenerator: 0 = NLipsum, 1 = Faker.net 
        //     strPath:          Path to save file to
        // cboTextGenerator.SelectedIndex should be a parameter
        private void CreateFile(int intTextGenerator, string strPath, ref int intFilesCreated)
        {
            try
            {
                string strFileName = strPath + "\\" + GenerateFileName(intTextGenerator);

                if (!File.Exists(strPath))
                {
                    using (FileStream fs = File.Create(strPath))
                    {
                        // Todo: Figure out a better way to predict how many paragraphs we need
                        //      10 = roughly 7kb
                        //     100 = roughly 68-76kb
                        var strFileContents = GenerateFileContents(intTextGenerator);

                        byte[] info = new UTF8Encoding(true).GetBytes(String.Join(Environment.NewLine, strFileContents));

                        fs.Write(info, 0, info.Length);

                        txtLog.Text += Environment.NewLine + "Created file '" + strFileName + "' with " + info.Length + " bytes";

                        intFilesCreated++;
                    }
                }
                else
                {
                    txtLog.Text += Environment.NewLine + "Error creating file, file already exists.  Filename: " + strFileName;
                }
            }
            catch (Exception ex)
            {
                txtLog.Text += Environment.NewLine + "Error creating file " + ex.ToString();
            }
        }

        public string GenerateFileName(int intTextGenerator)
        {
            var lgen = new NLipsum.Core.LipsumGenerator();
            string strFileName = String.Empty;
            StringBuilder sbFileName = new StringBuilder();
            string newWord = String.Empty;

            switch (intTextGenerator)
            {
                // Use NLipsum
                case 0:
                    {
                        for (int i = 0; i <= nudFileNameWordCount.Value; i++)
                        {
                            newWord = lgen.RandomWord();
                            newWord = newWord != String.Empty ? newWord.Substring(0, 1).ToUpper() + newWord.Substring(1) : newWord;
                            sbFileName.Append(newWord);
                            if (i != nudFileNameWordCount.Value) sbFileName.Append(" ");
                        }
                    }
                    break;

                // User Faker.net
                case 1:
                    {
                        var newWords = Faker.Lorem.Words((int)nudFileNameWordCount.Value);

                        foreach (var word in newWords)
                        {
                            newWord = word.Substring(0, 1).ToUpper() + word.Substring(1);
                            sbFileName.Append(newWord);
                            if (word != newWords.Last()) sbFileName.Append(" ");
                        }
                    }
                    break;
            }

            sbFileName.Append(".txt");
            strFileName = sbFileName.ToString();

            return strFileName;
        }

        public List<string> GenerateFileContents(int intTextGenerator)
        {
            List<string> strContents = new List<string>();

            switch (intTextGenerator)
            {
                // Use NLipsum
                case 0:
                    {
                        var lgen = new NLipsum.Core.LipsumGenerator();
                        strContents = lgen.GenerateParagraphs(10, Paragraph.Medium);
                    }
                    break;

                // User Faker.net
                case 1:
                    {
                        strContents = Faker.Lorem.Paragraphs(10).ToList();
                    }
                    break;
            }

            return strContents;
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
            string strPath = txtFilePath.Text;
            int intTextGenerator = cboTextGenerator.SelectedIndex;
            int intFileCount = (int)nudFileCount.Value;

            CreateFiles(intTextGenerator, intFileCount, strPath);
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

        public void btnClearLog_Click(object sender, EventArgs e)
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

        private void timerElapsed_Tick(object sender, EventArgs e)
        {
            try
            {
                lblElapsed.Text = "Elapsed Time: " + swElapsed.Elapsed.ToString();
            }
            catch (Exception ex)
            {
                txtLog.Text += Environment.NewLine + "Error in timerElapsed_Tick. " + ex.ToString();
            }
        }

        #endregion
    }
}