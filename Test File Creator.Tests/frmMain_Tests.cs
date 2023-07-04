using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Test_File_Creator;

namespace Test_File_Creator.Tests
{
    [TestClass]
    public class frmMain_Tests
    {
        [TestMethod()]
        public void GenerateFiles_Create5Files()
        {
            // Arrange
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {@"c:\Source\Test File Creator Output\", new MockFileData("Lorem ipsum")},
                {@"c:\Source\Test File Creator Output\test.txt", new MockFileData("Test File Creator Output")}
            });

            frmMain frm = new frmMain(mockFileSystem);
            int intFilesCreated = 0;
            int intFilesToCreate = 5;
            string strPath = "C:\\Source\\Test File Creator Output";            

            // Act
            for (int i = 0; i < intFilesToCreate; i++)
            {
                string strFileName = frm.GenerateFileName(0, 5);
                frm.GenerateFile(ref intFilesCreated, ref strFileName, 0, strPath);

                Assert.IsTrue(mockFileSystem.FileExists(@strPath + "\\" + strFileName));
            }

            // Assert
            Assert.IsTrue(intFilesCreated == intFilesToCreate);
        }

        [TestMethod()]
        [DataRow(0, 5)]
        [DataRow(1, 5)]
        public void GenerateFileName_Test(int intTextGenerator, int intFileNameWordCount)
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            frmMain frm = new frmMain(mockFileSystem);

            // Act
            String strFilename = frm.GenerateFileName(intTextGenerator, intFileNameWordCount);

            // Assert
            Assert.IsTrue(!String.IsNullOrEmpty(strFilename));
        }

        [TestMethod()]
        [DataRow(5, 5)]
        [DataRow(1, 500)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateFileName_InvalidGenerator_Test(int intTextGenerator, int intFileNameWordCount)
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            frmMain frm = new frmMain(mockFileSystem);

            // Act
            String strFilename = frm.GenerateFileName(intTextGenerator, intFileNameWordCount);

            // Assert
            // Should throw an exception above
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(1)]
        public void GenerateFileContents_Test(int intTextGenerator)
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            frmMain frm = new frmMain(mockFileSystem);

            // Act
            List<string> lstContents = frm.GenerateFileContents(intTextGenerator);

            // Assert
            Assert.IsTrue(lstContents.Count > 0);
            Assert.IsTrue(lstContents != null);
        }

        [TestMethod()]
        [DataRow(5)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateFileContents_InvalidGenerator_Test(int intTextGenerator)
        {
            // Arrange
            var mockFileSystem = new MockFileSystem();
            frmMain frm = new frmMain(mockFileSystem);

            // Act
            List<string> strFilename = frm.GenerateFileContents(intTextGenerator);

            // Assert
            // Should throw an exception above
        }

        [TestInitialize]
        public void App_Initialized_Successfully()
        {
            // Arrange
            Program pg = new Program();

            // Act
            // Assert
        }
    }
}