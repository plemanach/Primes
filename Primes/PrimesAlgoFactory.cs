using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public static class PrimesAlgoFactory
    {
        public static IPrimeAlgo CreateAlgo()
        {
            return new SegmentedSieveAlgo();
        }
    }
}
