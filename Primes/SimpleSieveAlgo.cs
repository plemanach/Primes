using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Primes
{
    /// <summary>
    /// This class implement the algo Sieve of Eratosthenes
    /// https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
    /// </summary>
    public class SimpleSieveAlgo
    {
        const int limitMax = (int.MaxValue - 1);


        /// <summary>
        /// Find the Nth Prime numbers
        /// </summary>
        /// <param name="numberOfPrime">Number of primes</param>
        /// <returns>The Nth prime numbers</returns>
        public IEnumerable<long> FindPrimes(long numberOfPrime)
        {
            return FindPrimesLimit(ApproximateNthPrimeLimit((int)numberOfPrime)).Take((int)numberOfPrime);
        }

        private int ApproximateNthPrimeLimit(int numberOfPrime)
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
                throw new ArgumentException(nameof(numberOfPrime) + " has overpass its limit.");
            }

            return (int)p;
        }

        /// <summary>
        /// Find Prime number below the <paramref name="limit"/>
        /// </summary>
        /// <param name="limit">Limit</param>
        /// <returns>The prime numbers below the limit</returns>
        public IEnumerable<long> FindPrimesLimit(int limit)
        {
            if (limit > limitMax)
            {
                throw new ArgumentException(nameof(limit) + " has overflow its limit:" + limitMax);
            }

            BitArray primes = new BitArray(limit + 1, true);

            Sieve(primes, 2, limit);

            for (int i = 2; i <= limit; i++)
            {
                if (primes[i])
                    yield return i;
            }
        }

        protected void Sieve(BitArray primes, int start, int limit)
        {
            for (long i = start; i * i <= limit; i++)
            {
                if (primes[(int)i])
                {
                    for (long j = i * 2; j <= limit; j += i)
                    {
                        primes[(int)j] = false;
                    }

                }
            }
        }
    }
}
