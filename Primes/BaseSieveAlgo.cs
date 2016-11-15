using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public class BaseSieveAlgo
    {
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
            throw new NotImplementedException();
        }
    }
}
