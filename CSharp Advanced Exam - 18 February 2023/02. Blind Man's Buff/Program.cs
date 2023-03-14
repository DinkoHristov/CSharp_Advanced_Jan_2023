using System;
using System.Drawing;
using System.Linq;

namespace _02._Blind_Man_s_Buff
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

            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (currRow[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int touchedPlayers = 0;
            int movesMade = 0;
            int totalPlayers = 3;
            bool isAllPlayersTouched = false;

            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "Finish")
            {
                if (direction == "up")
                {
                    if (playerRow - 1 >= 0 &&
                        matrix[playerRow - 1, playerCol] != 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (playerRow + 1 < rows &&
                        matrix[playerRow + 1, playerCol] != 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow++;
                    }
                }
                else if (direction == "right")
                {
                    if (playerCol + 1 < cols &&
                        matrix[playerRow, playerCol + 1] != 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol++;
                    }
                }
                else if (direction == "left")
                {
                    if (playerCol - 1 >= 0 &&
                        matrix[playerRow, playerCol - 1] != 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol--;
                    }
                }

                if (matrix[playerRow, playerCol] == 'P')
                {
                    totalPlayers--;
                    matrix[playerRow, playerCol] = '-';
                    touchedPlayers++;
                    movesMade++;

                    if (totalPlayers == 0)
                    {
                        matrix[playerRow, playerCol] = 'B';
                        isAllPlayersTouched = true;
                        break;
                    }
                }
                else if (matrix[playerRow, playerCol] == '-')
                {
                    movesMade++;
                }

                matrix[playerRow, playerCol] = 'B';
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedPlayers} Moves made: {movesMade}");
        }
    }
}
