namespace Bytes.MSTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BytesMSTests
    {
        [TestMethod]
        public void InsertNumber_Passed8_15_3_8_Retunrs120()
        {
            int expected = 120;

            int actual = Bytes.InsertNumber(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_Passed8_15_0_0_Returns9()
        {
            int expected = 9;

            int actual = Bytes.InsertNumber(8, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_Passed15_15_0_0_Returns15()
        {
            int expected = 15;

            int actual = Bytes.InsertNumber(15, 15, 0, 0);

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
