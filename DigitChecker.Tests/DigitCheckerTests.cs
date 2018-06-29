namespace DigitChecker.Tests
{
    using System;
    using System.Collections;

    using NUnit.Framework;

    [TestFixture]
    public class DigitCheckerTests
    {
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 5, ExpectedResult = new[] { 5, 15 })]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 6, ExpectedResult = new[] { 6, 68, 69 })]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, -6, 7, 68, 69, 70, 15, 17 }, 6, ExpectedResult = new[] { -6, 68, 69 })]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 6, ExpectedResult = new[] { 6, 68, 69 })]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, -7, 68, 69, 70, 15, -17 }, 7, ExpectedResult = new[] { 7, -7, 70, -17 })]
        public int[] FilerDigits_ResultOnlyElementsWithPassedDigit(int[] array, int digit) =>
            DigitChecker.FilterDigits(array, digit);

        [Test]
        public void FilterDigits_ResultIsEmptyArray()
        {
            var array = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 70, 15, 17 };
            int digit = 9;
            var expectedResult = new int[0];

            int[] actualResult = DigitChecker.FilterDigits(array, digit);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test, TestCaseSource(typeof(TestsData), nameof(TestsData.GetData))]
        public int[] FilterDigits_DataFromSource_FilerDigits_ResultOnlyElementsWithPassedDigit(int[] array, int digit) =>
            DigitChecker.FilterDigits(array, digit);


        [Test]
        public void FilterDigits_ArrayIsNull_ThrowsArgumentNullException() => 
            Assert.Throws<ArgumentNullException>(() => DigitChecker.FilterDigits(null, 0));

        [Test]
        public void FilterDigits_DigitIsOutOfRange_ThrowsArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>( () => DigitChecker.FilterDigits(new int[1], 10));
    }

    public class TestsData
    {
        public static IEnumerable GetData
        {
            get
            {
                yield return new TestCaseData(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 8).Returns(new[] { 68 });
                yield return new TestCaseData(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 14, 17 }, 4).Returns(new[] { 4, 14 });
            }
        }
    }
}
