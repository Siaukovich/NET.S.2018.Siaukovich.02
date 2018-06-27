namespace Bytes
{
    using System;

    public static class Bytes
    {
        /// <summary>
        /// Copies bits of numberSource from position i to j 
        /// to the least significant bits of numberIn.
        /// </summary>
        /// <param name="numberSource">
        /// Number from which method copies bits.
        /// </param>
        /// <param name="numberIn">
        /// Number to the start of which bits are copied.
        /// </param>
        /// <param name="i">
        /// Start position of copying in numberSource.
        /// </param>
        /// <param name="j">
        /// End position of copying in numberSource.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            const int LENGTH = 32; // Length of bit representation of Int32.
            ThrowIfInvalidParameters(i, j, LENGTH);

            char[] numberSourceBits = ToBitsArray(numberSource);
            string numberInBits = ToBitsString(numberIn);

            int copyPartLength = j - i + 1;
            int copyStartIndex = LENGTH - copyPartLength;
            int destinationIndex = LENGTH - 1 - j;

            numberInBits.CopyTo(copyStartIndex, numberSourceBits, destinationIndex, copyPartLength);

            return ConvertToInt32(numberSourceBits);
        }

        private static void ThrowIfInvalidParameters(int i, int j, int LENGTH)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be less than {nameof(j)}.");
            }

            if (j > LENGTH)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "j is bigger than length of Int32 bit representation.");
            }
        }

        /// <summary>
        /// Converts number to char array that is a bit representation of it. 
        /// Most significant digits are in the left.
        /// </summary>
        /// <param name="number">
        /// Number to convert.
        /// </param>
        /// <returns>
        /// The <see cref="char[]"/>.
        /// Number bit representation as char array.
        /// </returns>
        private static char[] ToBitsArray(int number)
        {
            // ToString method doesn't return most significant zeros, 
            // so we need to add them manually with String's PadLeft method.
            return Convert.ToString(number, 2).PadLeft(32, '0').ToCharArray();
        }

        /// <summary>
        /// Converts number to a string that is a bit representation of it. 
        /// Most significant digits are in the left.
        /// </summary>
        /// <param name="number">
        /// Number to convert.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// Number bit representation as string.
        /// </returns>
        private static string ToBitsString(int number) => new string(ToBitsArray(number));

        /// <summary>
        /// Converts bit representation of number as char array to corresponding Int32 value.
        /// </summary>
        /// <param name="numberSourceBits">
        /// Char array of bits.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// Integer that was converted from bits array.
        /// </returns>
        private static int ConvertToInt32(char[] numberSourceBits) => Convert.ToInt32(new string(numberSourceBits), 2);
    }
}
