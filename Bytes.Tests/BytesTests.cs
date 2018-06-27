namespace Bytes.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BytesTests
    {
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        public int InsertNumber_ValidInput_ValidResult(int numberSource, int numberIn, int i, int j) =>
            Bytes.InsertNumber(numberSource, numberIn, i, j);

        [Test]
        public void InsertNumber_IGreaterThanJ_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Bytes.InsertNumber(15, 15, 11, 5));
        }

        [Test]
        public void InsertNumber_JGreaterThan32_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Bytes.InsertNumber(15, 15, 35, 33));
        }
    }
}
