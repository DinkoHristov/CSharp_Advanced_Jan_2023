using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] charMatrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] currChars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    charMatrix[row, col] = currChars[col];
                }
            }

            int squareCount = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char currRow = charMatrix[row, col];
                    char currCol = charMatrix[row, col + 1];
                    char nextRow = charMatrix[row + 1, col];
                    char nextCol = charMatrix[row + 1, col + 1];

                    if (currRow == currCol && currCol == nextRow && nextRow == nextCol)
                    {
                        squareCount++;
                    }
                }
            }

            Console.WriteLine(squareCount);
        }
    }
}
