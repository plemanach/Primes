using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var primesTools = PrimeToolsFactory.CreatePrimesTools(Console.Out);
            primesTools.Execute(args);
        }
    }
}
