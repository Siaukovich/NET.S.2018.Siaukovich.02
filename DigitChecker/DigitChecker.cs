namespace DigitChecker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class with single method that filters passed array in the way
    /// that the result array's elements must contain passed digit.
    /// </summary>
    public static class DigitChecker
    {
        /// <summary>
        /// Filters passed array. Returns array that consists only 
        /// from elements that contain passed digit.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be filtered.
        /// </param>
        /// <param name="digit">
        /// Digit that should be in result array's elements.
        /// </param>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// Filtered array.
        /// </returns>
        public static int[] FilterDigits(int[] array, int digit)
        {
            ThrowIfInvalidParameters(array, digit);

            var matchingDigits = new List<int>();
            foreach (int number in array)
            {
                if (ContainsDigit(number, digit))
                {
                    matchingDigits.Add(number);
                }
            }

            int[] answer = ToArray(matchingDigits);

            return answer;
        }

        /// <summary>
        /// Checks if passed parameters are valid. 
        /// If they are not valid, throws corresponding exception.
        /// </summary>
        /// <param name="array">
        /// Array that must be not-null array.
        /// </param>
        /// <param name="digit">
        /// Digit that must be from 0 to 9 inclusively.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if digit is less than 0 or greater than 9.
        /// </exception>
        private static void ThrowIfInvalidParameters(int[] array, int digit)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be in range from 0 to 9 inclusively.");
            }
        }

        /// <summary>
        /// Checks if passed number contains passed digit.
        /// </summary>
        /// <param name="number">
        /// Number that needs to be checked.
        /// </param>
        /// <param name="digit">
        /// Digit that may be in the number.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if number contains digit, false otherwise.
        /// </returns>
        private static bool ContainsDigit(int number, int digit)
        {
            if (number < 0)
            {
                number *= -1;
            }

            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        /// <summary>
        /// Converts list of ints to array of ints.
        /// </summary>
        /// <param name="list">
        /// List to convert.
        /// </param>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        private static int[] ToArray(List<int> list)
        {
            var array = new int[list.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = list[i];
            }

            return array;
        }
    }
}
