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

        [TestMethod()]
        public void FindPrimesLimitHandleMaxNumberWellTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var primesResult = primesAlgo.FindPrimesLimit(int.MaxValue - 1).Last();
            var primeExpected = 2147483629;
            Assert.AreEqual(primeExpected, primesResult);
        }

        [TestMethod()]
        public void FindPrimesTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var expectedPrimes = new long[] { 2, 3, 5, 7 };
            var primesResult = primesAlgo.FindPrimes(4).ToArray();
            CollectionAssert.AreEqual(expectedPrimes, primesResult);
        }

        [TestMethod()]
        public void FindPrimesWith6PrimesTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var expectedPrimes = new long[] { 2, 3, 5, 7, 11, 13 };
            var primesResult = primesAlgo.FindPrimes(6).ToArray();
            CollectionAssert.AreEqual(expectedPrimes, primesResult);
        }

        [TestMethod()]
        public void FindPrimesWith100KPrimesTest()
        {
            var primesAlgo = new SimpleSieveAlgo();
            var expectedPrime = 1299709;
            var primeResult = primesAlgo.FindPrimes(100000).Last();
            Assert.AreEqual(expectedPrime, primeResult);
        }
    }
}