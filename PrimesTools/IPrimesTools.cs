namespace PrimesTools
{
    public interface IPrimesTools
    {
        void PrintNthPrimeNumberMultiplicationMatrix(long numberOfPrime);
        bool TryValidateArguments(string[] args, out long numberOfPrime);
        void Execute(string[] args);
        string Usage { get; }
    }
}