namespace EpamDay2
{
    using System;

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
            int swapIndex = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (!ContainsDigit(array[i], digit))
                {
                    continue;
                }

                Swap(ref array[swapIndex], ref array[i]);
                swapIndex++;
            }

            Array.Resize(ref array, swapIndex);

            return array;
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
        /// Swaps values of two passed elements.
        /// </summary>
        /// <param name="a">
        /// First element.
        /// </param>
        /// <param name="b">
        /// Second element.
        /// </param>
        private static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
