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

            cboFileSizeMin.SelectedIndex = 0;
            cboFileSizeMax.SelectedIndex = 0;

            //txtPath.Text = @"C:\Source\Test File Creator\x";
            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.InitialDirectory = txtPath.Text;
            DialogResult drFolder = folderBrowserDialog.ShowDialog(this);
            if (drFolder == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
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
                    sbFileName.Append(lgen.RandomWord());
                    if (i != nudFileNameWordCount.Value - 1) sbFileName.Append(" ");
                }
                sbFileName.Append(".txt");
                strFileName = sbFileName.ToString();

                string strPath = txtPath.Text + "\\" + strFileName;
                //string strPath = txtPath.Text + "\\" + lgen.GenerateWords(1)[0] + ".txt";

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
                        txtLog.Text += Environment.NewLine + "Created file " + strFileName + " with " + ((int)nudFileSizeMax.Value > info.Length ? info.Length : (int)nudFileSizeMax.Value) + " bytes";

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

            txtLog.Text = "Starting to generate " + nudFileCount.Value + " files at " + txtPath.Text + Environment.NewLine;
            for (int i = 0; i < nudFileCount.Value; i++)
            {
                // Todo: Breakout filename generation, content creation, and file creation into separate methods
                CreateFiles(ref intFilesCreated);
            }
            txtLog.Text += Environment.NewLine + Environment.NewLine + intFilesCreated + " Files Created!";
        }

        private void toolstrip_File_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolstrip_Help_About_Click(object sender, EventArgs e)
        {
            try
            {
                frmAbout frmAbout = new frmAbout();
                frmAbout.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}