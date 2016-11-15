using System;
using System.Collections;
using System.Collections.Generic;

namespace Primes
{
    public class SegmentedSieveAlgo : BaseSieveAlgo, ISieveAlgo
    {
        const int l1dCacheSize = 32768;
        const long limitMax = (long)(int.MaxValue - 1) * (long)(int.MaxValue - 1);

        public IEnumerable<long> FindPrimes(long numberOfPrime)
        {
            return FindPrimesLimit(ApproximateNthPrimeLimit(numberOfPrime, limitMax), numberOfPrime);
        }

        public IEnumerable<long> FindPrimesLimit(long limit)
        {
            return FindPrimesLimit(limit, limitMax);
        }

        private IEnumerable<long> FindPrimesLimit(long limit, long numberOfPrime = limitMax)
        {
            long sqrt = (long)Math.Sqrt(limit);

            if (sqrt > (int.MaxValue - 1))
            {
                throw new ArgumentException(nameof(limit) + " has a maxium value of " + (long)limitMax);
            }

            int segmentSize = (int)Math.Max(sqrt, l1dCacheSize);

            long count = 1;
            long s = 3;
            long n = 3;

            BitArray isPrimes = new BitArray((int)sqrt + 1, true);

            for (int i = 2; i * i <= sqrt; i++)
            {
                if (isPrimes[i])
                {
                    for (long j = i * i; j <= sqrt; j += i)
                    {
                        isPrimes[(int)j] = false;
                    }
                }
            }

            BitArray sieve = new BitArray(segmentSize, true);
            List<long> primes = new List<long>();
            List<long> next = new List<long>();

            for (long low = 0; low <= limit; low += segmentSize)
            {

                sieve.SetAll(true);

                long high = Math.Min(low + segmentSize - 1, limit);

                for (; s * s <= high; s += 2)
                {
                    if (isPrimes[(int)s])
                    {
                        primes.Add(s);
                        next.Add((s * s - low));
                    }
                }

                // sieve the current segment
                for (int i = 0; i < primes.Count; i++)
                {
                    long j = next[i];
                    for (long k = primes[i] * 2; j < segmentSize; j += k)
                        sieve[(int)j] = false;
                    next[i] = j - segmentSize;
                }

                if (count == 1) //Special case for prime 2
                {
                    yield return 2;
                }

                for (; n <= high; n += 2)
                {
                    if (sieve[(int)(n - low)]) // n is a prime
                    {
                        yield return n;
                        count++;
                        if (count == numberOfPrime)
                            yield break;
                    }
                }
            }
        }
    }
}
