using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primes;
using System;
using System.Linq;


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

        [TestMethod()]
        public void FindPrimesTest()
        {
            var primesAlgo = new SegmentedSieveAlgo();
            var expectedPrimes = new long[] { 2, 3, 5, 7 };
            var primesResult = primesAlgo.FindPrimes(4).ToArray();
            CollectionAssert.AreEqual(expectedPrimes, primesResult);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void FindPrimesWithMaximumNumberThrowExceptionTest()
        {
            var primesAlgo = new SegmentedSieveAlgo();
            long limit = ((long)(int.MaxValue - 1)) * ((long)(int.MaxValue - 1));
            var primesResult = primesAlgo.FindPrimes(limit).Last();
        }

        [TestMethod]
        public void FindPrimesWith1BillionPrimesTest()
        {
            var primesAlgo = new SegmentedSieveAlgo();
            var expectedPrime = 22801763489;
            var primeResult = primesAlgo.FindPrimes(1000000000).Last();
            Assert.AreEqual(expectedPrime, primeResult);
        }

        [TestMethod]
        public void FindPrimesWith1PrimeTest()
        {
            var primesAlgo = new SegmentedSieveAlgo();
            var expectedPrime = 2;
            var primeResult = primesAlgo.FindPrimes(1).Last();
            Assert.AreEqual(expectedPrime, primeResult);
        }

        [TestMethod()]
        public void GetPrimesMultiplicationTableTest()
        {
            Assert.Fail();
        }
    }
}