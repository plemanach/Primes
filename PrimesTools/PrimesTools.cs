using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesTools
{
    public class PrimesTools
    {
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
