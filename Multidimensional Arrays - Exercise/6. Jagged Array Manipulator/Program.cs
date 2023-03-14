using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] currNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = new int[currNumbers.Length];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = currNumbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                int firstArrayLength = jaggedArray[row].Length;
                int arrayBelowLength = jaggedArray[row + 1].Length;

                if (firstArrayLength == arrayBelowLength)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];

                if (commandType == "Add")
                {
                    int row = int.Parse(commandArgs[1]);
                    int column = int.Parse(commandArgs[2]);
                    int value = int.Parse(commandArgs[3]);

                    if (row >= 0 && row < jaggedArray.GetLength(0) &&
                        column >= 0 && column < jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] += value;
                    }
                }
                else if (commandType == "Subtract")
                {
                    int row = int.Parse(commandArgs[1]);
                    int column = int.Parse(commandArgs[2]);
                    int value = int.Parse(commandArgs[3]);

                    if (row >= 0 && row < jaggedArray.GetLength(0) &&
                        column >= 0 && column < jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col] + " "}");
                }

                Console.WriteLine();
            }
        }
    }
}
