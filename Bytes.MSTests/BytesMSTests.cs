namespace Bytes.MSTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);
            int numberSource = Convert.ToInt32(TestContext.DataRow["NumberSource"]);
            int NumberIn = Convert.ToInt32(TestContext.DataRow["NumberIn"]);
            int i = Convert.ToInt32(TestContext.DataRow["I"]);
            int j = Convert.ToInt32(TestContext.DataRow["J"]);


            int actual = Bytes.InsertNumber(numberSource, NumberIn, i, j);

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
