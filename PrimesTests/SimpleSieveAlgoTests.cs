using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primes;
using System;
using System.Linq;

namespace Primes.Tests
{
    [TestClass()]
    public class SimpleSieveAlgoTests
    {
        [TestMethod()]
        public void FindPrimesLimitTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var expectedPrimes = new long[] { 2, 3, 5, 7 };
            var primesResult = primesAlgo.FindPrimesLimit(10).ToArray();
            CollectionAssert.AreEqual(expectedPrimes, primesResult);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void FindPrimesLimitWithTooBigNumberThrowArgumentExeptionTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var primesResult = primesAlgo.FindPrimesLimit(int.MaxValue).ToArray();
        }
    }
}