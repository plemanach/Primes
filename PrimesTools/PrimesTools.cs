using Primes;
using System.IO;

namespace PrimesTools
{
    public class PrimesTools : IPrimesTools
    {
        string _usage = "usage: PrimesTools.exe n\r\nn is a number limited to this range[1," + (long.MaxValue - 1) + "]\r\n";

        IPrimeAlgo _primeAglo;
        IMatrixFormater<long?> _matrixFormater;
        TextWriter _textWriter;

        public PrimesTools(IPrimeAlgo primeAlgo, IMatrixFormater<long?> matrixFormater, TextWriter textWriter)
        {
            _primeAglo = primeAlgo;
            _matrixFormater = matrixFormater;
            _textWriter = textWriter;
        }

        public string Usage { get { return _usage; } }

        public void PrintNthPrimeNumberMultiplicationMatrix(long numberOfPrime)
        {
            var matrix = _primeAglo.GetPrimesMultiplicationTable(numberOfPrime);
            _matrixFormater.Format(matrix);
        }

        public void Execute(string[] args)
        {
            long numberOfPrime = 1;

            if (this.TryValidateArguments(args, out numberOfPrime))
            {
                this.PrintNthPrimeNumberMultiplicationMatrix(numberOfPrime);
            }
            else
            {
                PrintUsage();
            }
        }

        public void PrintUsage()
        {
            _textWriter.Write(Usage);
        }

        public bool TryValidateArguments(string[] args, out long numberOfPrime)
        {
            bool argumentsAreValid = false;
            numberOfPrime = 1;

            if (args.Length != 1)
            {
                argumentsAreValid = false;
            }
            else
            {
                bool numberOfPrimeParsed = long.TryParse(args[0], out numberOfPrime);
                if (!numberOfPrimeParsed)
                {
                    argumentsAreValid = false;
                }
                else
                {
                    if (numberOfPrime >= 1)
                    {
                        argumentsAreValid = true;
                    }
                    else
                    {

                    }
                }
            }
            return argumentsAreValid;
        }
    }
}
