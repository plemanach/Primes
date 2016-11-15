using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    public class MatrixFormater<T>
    {
        TextWriter _textWriter;
        public MatrixFormater(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_textWriter != null)
                {
                    _textWriter.Dispose();
                    _textWriter = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Format(T[,] matrix)
        {
            int padSize = GetPadSize(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                _textWriter.Write('|');
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var item = matrix[row, column];

                    _textWriter.Write("  ");
                    if (item != null)
                    {
                        _textWriter.Write(item.ToString().PadLeft(padSize));
                    }
                    else
                    {
                        _textWriter.Write("".PadLeft(padSize));
                    }

                    _textWriter.Write('|');
                }
                _textWriter.WriteLine();
            }
        }

        private int GetPadSize(T[,] matrix)
        {
            int padSize = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var item = matrix[row, column];

                    if (item != null)
                    {
                        int stringSize = item.ToString().Length;
                        if (stringSize > padSize)
                        {
                            padSize = stringSize;
                        }
                    }
                }
            }
            return padSize;
        }
    }
}
