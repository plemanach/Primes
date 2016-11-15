using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes.Tests
{
    [TestClass()]
    public class MatrixFormaterTests
    {
        [TestMethod()]
        public void Format4x4MatrixTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                MatrixFormater<long?> matrixFormater = new MatrixFormater<long?>(sw);
                long?[,] matrix = new long?[,] {
                    { null, 2, 3, 5 },
                    { 2, 4, 6, 10 },
                    { 3, 6, 9, 15 },
                    { 5, 10, 15, 25 }
                };

                matrixFormater.Format(matrix);
                var formatExpect = "|    |   2|   3|   5|\r\n|   2|   4|   6|  10|\r\n|   3|   6|   9|  15|\r\n|   5|  10|  15|  25|\r\n";
                sw.Flush();
                var formatResult = sw.ToString();
                Assert.AreEqual(formatExpect, formatResult);
            }
        }
    }
}