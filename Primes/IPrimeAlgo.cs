using System.Collections.Generic;

namespace Primes
{
    public interface IPrimeAlgo
    {
        IEnumerable<long> FindPrimes(long numberOfPrime);
        IEnumerable<long> FindPrimesLimit(long limit);
        long?[,] GetPrimesMultiplicationTable(long numberOfPrime);
    }
}