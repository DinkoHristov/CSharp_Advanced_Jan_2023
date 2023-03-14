using System;
using System.Linq;

namespace _5._Snake_Moves
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

            string snake = Console.ReadLine();

            int currentWordIndex = 0;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentWordIndex == snake.Length)
                        {
                            currentWordIndex = 0;
                        }

                        matrix[row, col] = snake[currentWordIndex];
                        currentWordIndex++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == snake.Length)
                        {
                            currentWordIndex = 0;
                        }

                        matrix[row, col] = snake[currentWordIndex];
                        currentWordIndex++;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
