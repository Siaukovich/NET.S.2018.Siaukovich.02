namespace Bytes.MSTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class for testing class Bytes.
    /// </summary>
    [TestClass]
    public class BytesMSTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "|DataDirectory|\\TestDataSource.xml",
                    "TestCase",
                    DataAccessMethod.Sequential)]
        [DeploymentItem("Bytes.MSTests\\TestDataSource.xml")]
        [TestMethod]
        public void InsertNumber_ValidInput_ValidResult()
        {
            int expected = int.Parse((string)TestContext.DataRow["ExpectedResult"]);
            int numberSource = int.Parse((string)TestContext.DataRow["NumberSource"]);
            int numberIn = int.Parse((string)TestContext.DataRow["NumberIn"]);
            int i = int.Parse((string)TestContext.DataRow["I"]);
            int j = int.Parse((string)TestContext.DataRow["J"]);

            int actual = Bytes.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_IGreaterThanJ_ThrowsArgumentOutOfRangeException() => Bytes.InsertNumber(15, 15, 11, 5);


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_JGreaterThan32_ThrowsArgumentOutOfRangeException() => Bytes.InsertNumber(15, 15, 35, 33);
    }
}
