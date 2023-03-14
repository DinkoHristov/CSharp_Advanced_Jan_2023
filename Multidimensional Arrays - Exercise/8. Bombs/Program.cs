using System;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                int[] currArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currArray[col];
                }
            }

            string[] bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int currBomb = 0; currBomb < bombs.Length; currBomb++)
            {
                string[] bombArgs = bombs[currBomb].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int bombRow = int.Parse(bombArgs[0]);
                int bombCol = int.Parse(bombArgs[1]);

                int bombPower = matrix[bombRow, bombCol];

                if (bombPower <= 0)
                {
                    //It's a dead cell
                    //Cannot explode again
                    continue;
                }

                if (bombRow - 1 >= 0 && bombRow - 1 < matrixSize)
                {
                    int currCell = matrix[bombRow - 1, bombCol];
                    if (currCell > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bombPower;
                    }
                }

                if (bombRow - 1 >= 0 && bombRow - 1 < matrixSize &&
                    bombCol - 1 >=0 && bombCol - 1 < matrixSize)
                {
                    int currCell = matrix[bombRow - 1, bombCol - 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombPower;
                    }
                }

                if (bombRow - 1 >= 0 && bombRow - 1 < matrixSize &&
                    bombCol + 1 >= 0 && bombCol + 1 < matrixSize)
                {
                    int currCell = matrix[bombRow - 1, bombCol + 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombPower;
                    }
                }

                if (bombCol - 1 >= 0 && bombCol - 1 < matrixSize)
                {
                    int currCell = matrix[bombRow, bombCol - 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bombPower;
                    }
                }

                if (bombCol + 1 >= 0 && bombCol + 1 < matrixSize)
                {
                    int currCell = matrix[bombRow, bombCol + 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bombPower;
                    }
                }

                if (bombRow + 1 >= 0 && bombRow + 1 < matrixSize)
                {
                    int currCell = matrix[bombRow + 1, bombCol];
                    if (currCell > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bombPower;
                    }
                }

                if (bombRow + 1 >= 0 && bombRow + 1 < matrixSize &&
                    bombCol - 1 >= 0 && bombCol - 1 < matrixSize)
                {
                    int currCell = matrix[bombRow + 1, bombCol - 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombPower;
                    }
                }

                if (bombRow + 1 >= 0 && bombRow + 1 < matrixSize &&
                    bombCol + 1 >= 0 && bombCol + 1 < matrixSize)
                {
                    int currCell = matrix[bombRow + 1, bombCol + 1];
                    if (currCell > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombPower;
                    }
                }

                //CurrBomb = 0, because it already explodes
                matrix[bombRow, bombCol] = 0;
            }

            int aliveCells = 0;
            int aliveCellsSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    int currCell = matrix[row, col];
                    if (currCell > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += currCell;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
