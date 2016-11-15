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
    public class SimpleSieveAlgo : BaseSieveAlgo
    {
        const int limitMax = (int.MaxValue - 1);


        /// <summary>
        /// Find the Nth Prime numbers
        /// </summary>
        /// <param name="numberOfPrime">Number of primes</param>
        /// <returns>The Nth prime numbers</returns>
        public IEnumerable<long> FindPrimes(long numberOfPrime)
        {
            return FindPrimesLimit(ApproximateNthPrimeLimit(numberOfPrime, limitMax)).Take((int)numberOfPrime);
        }

        /// <summary>
        /// Find Prime number below the <paramref name="limit"/>
        /// </summary>
        /// <param name="limit">Limit</param>
        /// <returns>The prime numbers below the limit</returns>
        public IEnumerable<long> FindPrimesLimit(long limit)
        {
            if (limit > limitMax)
            {
                throw new ArgumentException(nameof(limit) + " has overflow its limit:" + limitMax);
            }

            BitArray primes = new BitArray((int)limit + 1, true);

            Sieve(primes, 2, (int)limit);

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
