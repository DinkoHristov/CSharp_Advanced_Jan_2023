using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fieldSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = fieldSize[0];
            int cols = fieldSize[1];

            char[,] field = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currField = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currField[col];
                }
            }

            //Find player row and col
            int[] playerIndexes = CheckPLayerPosition(field);
            int playerRow = playerIndexes[0];
            int playerCol = playerIndexes[1];

            bool isPlayerOut = false;
            bool isBunnieMet = false;
            string directions = Console.ReadLine();
            for (int move = 0; move < directions.Length; move++)
            {
                char currDirection = directions[move];

                List<string> bunnies = BunniesIndexes(field);

                if (currDirection == 'U')
                {
                    if (playerRow - 1 >= 0 && playerRow - 1 < field.GetLength(0))
                    {
                        field[playerRow, playerCol] = '.';

                        if (field[playerRow - 1, playerCol] == 'B')
                        {
                            isBunnieMet = true;
                            playerRow = playerRow - 1;
                        }
                        else
                        {
                            playerRow = playerRow - 1;
                            field[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        isPlayerOut = true;
                    }

                    for (int bunnie = 0; bunnie < bunnies.Count; bunnie++)
                    {
                        string[] bunnieArgs = bunnies[bunnie].Split(",");
                        int bunnieRow = int.Parse(bunnieArgs[0]);
                        int bunnieCol = int.Parse(bunnieArgs[1]);

                        //Up
                        if (CheckUp(bunnieRow, bunnieCol, field))
                        {
                            //If the index is Valid
                            field[bunnieRow - 1, bunnieCol] = 'B';
                        }

                        //Down
                        if (CheckDown(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow + 1, bunnieCol] = 'B';
                        }

                        //Right
                        if (CheckRight(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol + 1] = 'B';
                        }

                        //Left
                        if (CheckLeft(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol - 1] = 'B';
                        }
                    }

                    if (field[playerRow, playerCol] == 'B' && !isPlayerOut)
                    {
                        //We have met a bunny
                        isBunnieMet = true;
                        break;
                    }

                    if (isPlayerOut && !isBunnieMet)
                    {
                        //Player is out and we won
                        break;
                    }

                    if (!isPlayerOut && isBunnieMet)
                    {
                        //Player met a bunny
                        break;
                    }
                }
                else if (currDirection == 'D')
                {
                    //Down
                    if (playerRow + 1 >= 0 && playerRow + 1 < field.GetLength(0))
                    {
                        field[playerRow, playerCol] = '.';

                        if (field[playerRow + 1, playerCol] == 'B')
                        {
                            isBunnieMet = true;
                            playerRow = playerRow + 1;
                        }
                        else
                        {
                            playerRow = playerRow + 1;
                            field[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        isPlayerOut = true;
                    }

                    for (int bunnie = 0; bunnie < bunnies.Count; bunnie++)
                    {
                        string[] bunnieArgs = bunnies[bunnie].Split(",");
                        int bunnieRow = int.Parse(bunnieArgs[0]);
                        int bunnieCol = int.Parse(bunnieArgs[1]);

                        //Up
                        if (CheckUp(bunnieRow, bunnieCol, field))
                        {
                            //If the index is Valid
                            field[bunnieRow - 1, bunnieCol] = 'B';
                        }

                        //Down
                        if (CheckDown(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow + 1, bunnieCol] = 'B';
                        }

                        //Right
                        if (CheckRight(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol + 1] = 'B';
                        }

                        //Left
                        if (CheckLeft(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol - 1] = 'B';
                        }
                    }

                    if (field[playerRow, playerCol] == 'B' && !isPlayerOut)
                    {
                        //We have met a bunny
                        isBunnieMet = true;
                        break;
                    }

                    if (isPlayerOut && !isBunnieMet)
                    {
                        //Player is out and we won
                        break;
                    }

                    if (!isPlayerOut && isBunnieMet)
                    {
                        //Player met a bunny
                        break;
                    }
                }
                else if (currDirection == 'R')
                {
                    //Right
                    if (playerCol + 1 >= 0 && playerCol + 1 < field.GetLength(1))
                    {
                        field[playerRow, playerCol] = '.';

                        if (field[playerRow, playerCol + 1] == 'B')
                        {
                            isBunnieMet = true;
                            playerCol = playerCol + 1;
                        }
                        else
                        {
                            playerCol = playerCol + 1;
                            field[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        isPlayerOut = true;
                    }

                    for (int bunnie = 0; bunnie < bunnies.Count; bunnie++)
                    {
                        string[] bunnieArgs = bunnies[bunnie].Split(",");
                        int bunnieRow = int.Parse(bunnieArgs[0]);
                        int bunnieCol = int.Parse(bunnieArgs[1]);

                        //Up
                        if (CheckUp(bunnieRow, bunnieCol, field))
                        {
                            //If the index is Valid
                            field[bunnieRow - 1, bunnieCol] = 'B';
                        }

                        //Down
                        if (CheckDown(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow + 1, bunnieCol] = 'B';
                        }

                        //Right
                        if (CheckRight(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol + 1] = 'B';
                        }

                        //Left
                        if (CheckLeft(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol - 1] = 'B';
                        }
                    }

                    if (field[playerRow, playerCol] == 'B' && !isPlayerOut)
                    {
                        //We have met a bunny
                        isBunnieMet = true;
                        break;
                    }

                    if (isPlayerOut && !isBunnieMet)
                    {
                        //Player is out and we won
                        break;
                    }

                    if (!isPlayerOut && isBunnieMet)
                    {
                        //Player met a bunny
                        break;
                    }
                }
                else if (currDirection == 'L')
                {
                    //Left
                    if (playerCol - 1 >= 0 && playerCol - 1 < field.GetLength(1))
                    {
                        field[playerRow, playerCol] = '.';

                        if (field[playerRow, playerCol - 1] == 'B')
                        {
                            isBunnieMet = true;
                            playerCol = playerCol - 1;
                        }
                        else
                        {
                            playerCol = playerCol - 1;
                            field[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        isPlayerOut = true;
                    }

                    for (int bunnie = 0; bunnie < bunnies.Count; bunnie++)
                    {
                        string[] bunnieArgs = bunnies[bunnie].Split(",");
                        int bunnieRow = int.Parse(bunnieArgs[0]);
                        int bunnieCol = int.Parse(bunnieArgs[1]);

                        //Up
                        if (CheckUp(bunnieRow, bunnieCol, field))
                        {
                            //If the index is Valid
                            field[bunnieRow - 1, bunnieCol] = 'B';
                        }

                        //Down
                        if (CheckDown(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow + 1, bunnieCol] = 'B';
                        }

                        //Right
                        if (CheckRight(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol + 1] = 'B';
                        }

                        //Left
                        if (CheckLeft(bunnieRow, bunnieCol, field))
                        {
                            field[bunnieRow, bunnieCol - 1] = 'B';
                        }
                    }

                    if (field[playerRow, playerCol] == 'B' && !isPlayerOut)
                    {
                        //We have met a bunny
                        isBunnieMet = true;
                        break;
                    }

                    if (isPlayerOut && !isBunnieMet)
                    {
                        //Player is out and we won
                        break;
                    }

                    if (!isPlayerOut && isBunnieMet)
                    {
                        //Player met a bunny
                        break;
                    }
                }
            }

            if (isPlayerOut && !isBunnieMet)
            {
                PrintField(field);
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                field[playerRow, playerCol] = 'B';
                PrintField(field);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        public static int[] CheckPLayerPosition(char[,] matrix)
        {
            int[] playerIndexes = new int[2];
            bool isPlayerFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerIndexes[0] = row;
                        playerIndexes[1] = col;
                        isPlayerFound = true;
                        break;
                    }
                }

                if (isPlayerFound)
                {
                    break;
                }
            }

            return playerIndexes;
        }

        public static List<string> BunniesIndexes(char[,] matrix)
        {
            List<string> bunniesIndexes = new List<string>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        string rowAndCol = row + "," + col;
                        bunniesIndexes.Add(rowAndCol);
                    }
                }
            }

            return bunniesIndexes;
        }

        public static bool CheckUp(int row, int col, char[,] matrix)
        {
            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        public static bool CheckDown(int row, int col, char[,] matrix)
        {
            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        public static bool CheckRight(int row, int col, char[,] matrix)
        {
            if (col + 1 >= 0 && col + 1 < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public static bool CheckLeft(int row, int col, char[,] matrix)
        {
            if (col - 1 >= 0 && col - 1 < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
