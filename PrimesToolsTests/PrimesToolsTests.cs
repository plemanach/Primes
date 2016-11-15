using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimesTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesTools.Tests
{
    [TestClass()]
    public class PrimesToolsTests
    {
        [TestMethod()]
        public void TryValidateArgumentsTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                var primesTools = PrimeToolsFactory.CreatePrimesTools(sw);
                string[] args = new[] { "1" };

                long numberOfPrimes = 0;
                bool isValid = primesTools.TryValidateArguments(args, out numberOfPrimes);

                Assert.IsTrue(isValid);
                Assert.AreEqual(1, numberOfPrimes);
            }
        }

        [TestMethod()]
        public void TryValidateArgumentsWithWrongNTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                var primesTools = PrimeToolsFactory.CreatePrimesTools(sw);
                string[] args = new[] { "0" };

                long numberOfPrimes = 0;
                bool isValid = primesTools.TryValidateArguments(args, out numberOfPrimes);

                Assert.IsFalse(isValid);
            }
        }

        [TestMethod()]
        public void ExecuteWithValidArgumentTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                var primesTools = PrimeToolsFactory.CreatePrimesTools(sw);
                string[] args = new[] { "3" };
                primesTools.Execute(args);
                var formatExpect = "|    |   2|   3|   5|\r\n|   2|   4|   6|  10|\r\n|   3|   6|   9|  15|\r\n|   5|  10|  15|  25|\r\n";
                var result = sw.ToString();
                Assert.AreEqual(formatExpect, result);
            }
        }

        [TestMethod()]
        public void ExecuteWithWrongArgumentPrintUsageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                var primesTools = PrimeToolsFactory.CreatePrimesTools(sw);
                string[] args = new[] { "0" };
                primesTools.Execute(args);
                var formatExpect = primesTools.Usage;
                var result = sw.ToString();
                Assert.AreEqual(formatExpect, result);
            }
        }

        [TestMethod()]
        public void ExecuteWithBigNumberOverTheLimitPrintUsageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                var primesTools = PrimeToolsFactory.CreatePrimesTools(sw);
                string[] args = new[] { "100001" };
                primesTools.Execute(args);
                var formatExpect = primesTools.Usage;
                var result = sw.ToString();
                Assert.AreEqual(formatExpect, result);
            }
        }
    }
}