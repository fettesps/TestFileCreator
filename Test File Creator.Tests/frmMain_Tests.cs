using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Test_File_Creator;

namespace Test_File_Creator.Tests
{
    [TestClass]
    public class frmMain_Tests
    {
        [TestMethod()]
        public void GenerateFiles_Test()
        {
            // Arrange
            // Act
            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(0, 5)]
        [DataRow(1, 5)]
        public void GenerateFileName_Test(int intTextGenerator, int intFileNameWordCount)
        {
            // Arrange
            frmMain frm = new frmMain();

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
            frmMain frm = new frmMain();

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
            frmMain frm = new frmMain();

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
            frmMain frm = new frmMain();

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