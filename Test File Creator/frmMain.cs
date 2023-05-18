using NLipsum.Core.Features;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO.Abstractions;

namespace Test_File_Creator
{
    public partial class frmMain : Form
    {
        #region Initialization

        Stopwatch swElapsed = new Stopwatch();
        IFileSystem _fs;

        public frmMain(IFileSystem fileSystem)
        {
            InitializeComponent();
            if (fileSystem != null) _fs = fileSystem;
            else _fs = new FileSystem();

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

        public void GenerateFile(ref int intFilesCreated, ref string strFileName, int intTextGenerator, string strPath)
        {
            try
            {
                string strFileNameAndPath = strPath + "\\" + strFileName;

                if (!File.Exists(strFileNameAndPath))
                {
                    using (Stream fs = _fs.File.Create(strFileNameAndPath))
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

        public string GenerateFileName(int intTextGenerator, int intFileNameWordCount)
        {
            var lgen = new NLipsum.Core.LipsumGenerator();
            string strFileName = String.Empty;
            StringBuilder sbFileName = new StringBuilder();
            string newWord = String.Empty;

            if (intFileNameWordCount > 50) throw new ArgumentOutOfRangeException("intFileNameWordCount");

            switch (intTextGenerator)
            {
                // Use NLipsum
                case 0:
                    {
                        for (int i = 0; i <= intFileNameWordCount; i++)
                        {
                            newWord = lgen.RandomWord();
                            newWord = newWord != String.Empty ? newWord.Substring(0, 1).ToUpper() + newWord.Substring(1) : newWord;
                            sbFileName.Append(newWord);
                            if (i != intFileNameWordCount) sbFileName.Append(" ");
                        }
                    }
                    break;

                // User Faker.net
                case 1:
                    {
                        var newWords = Faker.Lorem.Words((int)intFileNameWordCount);

                        foreach (var word in newWords)
                        {
                            newWord = word.Substring(0, 1).ToUpper() + word.Substring(1);
                            sbFileName.Append(newWord);
                            if (word != newWords.Last()) sbFileName.Append(" ");
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("intTextGenerator");
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
                default:
                    throw new ArgumentOutOfRangeException("intTextGenerator");
            }

            return strContents;
        }

        public void GenerateFiles()
        {
            int intFilesCreated = 0;
            swElapsed.Start();
            timerElapsed.Start();
            progressBar.Minimum = 0;
            progressBar.Maximum = (int)nudFileCount.Value;

            btnGenerate.Enabled = false;
            txtLog.Text = "Starting to generate " + nudFileCount.Value + " files at " + txtFilePath.Text + Environment.NewLine;
            for (int i = 0; i < nudFileCount.Value; i++)
            {
                string strFileName = GenerateFileName(cboTextGenerator.SelectedIndex, (int)nudFileNameWordCount.Value);
                GenerateFile(ref intFilesCreated, ref strFileName, cboTextGenerator.SelectedIndex, txtFilePath.Text);

                Application.DoEvents();
                progressBar.Value = i;
            }
            progressBar.Value = (int)nudFileCount.Value;

            txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
            timerElapsed.Stop();
            swElapsed.Stop();
            txtLog.Text += Environment.NewLine + Environment.NewLine + "Elapsed time: " + swElapsed.Elapsed.ToString();
            btnGenerate.Enabled = true;
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

        private void BrowseForFilePath()
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
            swElapsed.Start();
            timerElapsed.Start();
            progressBar.Minimum = 0;
            progressBar.Maximum = (int)nudFileCount.Value;

        #region Form Events

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFilePath();
        }

            txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
            timerElapsed.Stop();
            swElapsed.Stop();
            txtLog.Text += Environment.NewLine + Environment.NewLine + "Elapsed time: " + swElapsed.Elapsed.ToString();
            btnGenerate.Enabled = true;
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