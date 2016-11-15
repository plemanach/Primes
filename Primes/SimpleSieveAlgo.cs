using System;
using System.Collections;
using System.Collections.Generic;

namespace Primes
{
    public class SimpleSieveAlgo
    {
        const long limitMax = (int.MaxValue - 1);

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
