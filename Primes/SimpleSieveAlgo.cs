using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Primes
{
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
            return FindPrimesLimit(limitMax).Take((int)numberOfPrime);
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
