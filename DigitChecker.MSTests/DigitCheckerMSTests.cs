namespace DigitChecker.MSTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DigitCheckerMSTests
    {
        [TestMethod]
        public void FilterDigits_DigitThatIsNotInArray_ReturnsEmptyArray()
        {
            var array = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 70, 15, 17 };
            int digit = 9;
            var expectedResult = new int[0];

            int[] actualResult = DigitChecker.FilterDigits(array, digit);

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigits_NullArray_ThrowsArgumentNullException() => 
            DigitChecker.FilterDigits(null, 0);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigits_DigitIs10_ThrowsArgumentOutOfRangeException() =>
            DigitChecker.FilterDigits(new int[0], 10);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigits_DigitIsMinusOne_ThrowsArgumentOutOfRangeException() =>
            DigitChecker.FilterDigits(new int[0], -1);

        [TestMethod]
        public void FilterDigits_OrderedArrayWithNegativeNumbers_ReturnsValidAnswer()
        {
            int digit = 2;
            int[] array = Enumerable.Range(-100, 100).ToArray();
            int[] expected = array.Where(v => v.ToString().Contains(digit.ToString())).ToArray();

            int[] actual = DigitChecker.FilterDigits(array, digit);

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void FilterDigits_DigitThatIsNotInTheArray_ReturnsEmptyArray()
        {
            int digit = 2;
            int[] array = Enumerable.Range(-100, 100).Where(v => !v.ToString().Contains(digit.ToString())).ToArray();
            int[] expected = new int[0];

            int[] actual = DigitChecker.FilterDigits(array, digit);

            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}
