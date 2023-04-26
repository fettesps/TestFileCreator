using NLipsum.Core.Features;
using System.IO;
using System.Text;

namespace Test_File_Creator
{
    public partial class frmMain : Form
    {
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.InitialDirectory = txtFilePath.Text;
            DialogResult drFolder = folderBrowserDialog.ShowDialog(this);
            if (drFolder == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

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
                        //fs.Write(info, 0, (int)nudFileSizeMax.Value > info.Length ? info.Length : (int)nudFileSizeMax.Value);
                        txtLog.Text += Environment.NewLine + "Created file '" + strFileName + "' with " + ((int)nudFileSizeMax.Value > info.Length ? info.Length : (int)nudFileSizeMax.Value) + " bytes";

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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int intFilesCreated = 0;

            txtLog.Text = "Starting to generate " + nudFileCount.Value + " files at " + txtFilePath.Text + Environment.NewLine;
            for (int i = 0; i < nudFileCount.Value; i++)
            {
                // Todo: Breakout filename generation, content creation, and file creation into separate methods
                CreateFiles(ref intFilesCreated);
            }
            txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
        }

        private void toolstrip_File_Exit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["FileCount"] = (int)nudFileCount.Value;
            Properties.Settings.Default["FileSizeMin"] = (long)nudFileSizeMin.Value;
            Properties.Settings.Default["FileSizeMax"] = (long)nudFileSizeMax.Value;
            Properties.Settings.Default["FilenameWordCount"] = (int)nudFileNameWordCount.Value;
            Properties.Settings.Default["FilePath"] = txtFilePath.Text;
            Properties.Settings.Default.Save();

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
        }
    }
}