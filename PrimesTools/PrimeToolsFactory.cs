using Primes;
using System;
using System.IO;

namespace PrimesTools
{
    public static class PrimeToolsFactory
    {
        public static IPrimesTools CreatePrimesTools(TextWriter textWriter)
        {
            var primeAlgo = PrimesAlgoFactory.CreateAlgo();
            var matrixFormater = new MatrixFormater<long?>(textWriter);
            var primesTools = new PrimesTools(primeAlgo, matrixFormater, textWriter);
            return primesTools;
        }
    }
}
