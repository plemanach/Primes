using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes.Tests
{
    [TestClass()]
    public class SegmentedSieveAlgoTests
    {
        [TestMethod()]
        public void FindPrimesLimitTest()
        {
            var primesAlgo = new SegmentedSieveAlgo();
            var expectedPrimes = new long[] { 2, 3, 5, 7 };
            var primesResult = primesAlgo.FindPrimesLimit(10).ToArray();
            CollectionAssert.AreEqual(expectedPrimes, primesResult);
        }
    }
}