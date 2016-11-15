using System.Collections.Generic;

namespace Primes
{
    public interface ISieveAlgo
    {
        IEnumerable<long> FindPrimes(long numberOfPrime);
        IEnumerable<long> FindPrimesLimit(long limit);
        long?[,] GetPrimesMultiplicationTable(long numberOfPrime);
    }
}