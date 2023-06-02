using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_File_Creator;

namespace Test_File_Creator.Tests
{
    [TestClass]
    public class frmMain_Tests
    {
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
        public void CreateFiles_Test()
        {
            // Arrange
            // Act
            // Assert
            Assert.Fail();
        }
    }
}