namespace Bytes
{
    using System;
    using System.Security.Cryptography.X509Certificates;

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
            ThrowForInvalidParameters(i, j);

            int shiftedIn = numberIn << i;

            for (int k = i; k < j  + 1; ++k)
            {
                int mask = 1 << k;

                if ((shiftedIn & mask) != 0)
                {
                    numberSource |= mask;
                }
                else
                {
                    numberSource &= ~mask;
                }
            }
            
            return numberSource;
        }

        /// <summary>
        /// Checks if passed parameters are valid. 
        /// If they are not valid throws exceptions.
        /// </summary>
        /// <param name="i">
        /// Lower bound of bit range that will be copied.
        /// </param>
        /// <param name="j">
        /// Higher bound of bit range that will be copied.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown in three cases: i > j, j > sizeof(int) * 8, i \lt 0.
        /// </exception>
        private static void ThrowForInvalidParameters(int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} must be less than {nameof(j)}.");
            }

            int bitsInByte = 8;
            if (j > sizeof(int) * bitsInByte)
            {
                throw new ArgumentOutOfRangeException(nameof(j), $"{nameof(j)} is bigger than length of Int32 bit representation.");
            }

            if (i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), $"{nameof(i)} can not be less than 0.");
            }
        }
    }
}
