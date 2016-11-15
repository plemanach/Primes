using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public abstract class BaseSieveAlgo : ISieveAlgo
    {
        public abstract IEnumerable<long> FindPrimes(long numberOfPrime);

        public abstract IEnumerable<long> FindPrimesLimit(long limit);

        protected virtual long ApproximateNthPrimeLimit(long numberOfPrime, long limitMax)
        {
            double n = Convert.ToDouble(numberOfPrime);
            double p;
            if (numberOfPrime >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (numberOfPrime >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (numberOfPrime > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[numberOfPrime - 1];
            }
            else
            {
                p = 0;
            }

            if (p > limitMax)
            {
                throw new ArgumentException(nameof(numberOfPrime) + " Has overpass its limit.");
            }

            return (long)p;
        }

        public long?[,] GetPrimesMultiplicationTable(long numberOfPrime)
        {
            long tableSise = numberOfPrime + 1;

            var multiplication = new long?[tableSise, tableSise];

            int index = 1;
            foreach (long prime in FindPrimes(numberOfPrime))
            {
                multiplication[0, index] = prime;
                multiplication[index, 0] = prime;
                index++;
            }

            for (int column = 1; column < tableSise; column++)
            {
                for (int row = 1; row < tableSise; row++)
                {
                    multiplication[row, column] = multiplication[0, column] * multiplication[row, 0];
                }
            }

            return multiplication;
        }
    }
}
