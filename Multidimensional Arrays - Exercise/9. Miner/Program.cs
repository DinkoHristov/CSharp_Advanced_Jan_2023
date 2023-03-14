using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] minerMovement = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[,] field = new char[fieldSize, fieldSize];
            for (int row = 0; row < fieldSize; row++)
            {
                char[] currPlace = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = currPlace[col];
                }
            }

            int lastRow = 0;
            int lastCol = 0;
            bool isEnd = false;
            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    if (field[row, col] == 's')
                    {
                        //This is the place, where our miner start
                        lastRow = row;
                        lastCol = col;

                        for (int move = 0; move < minerMovement.Length; move++)
                        {
                            string currMovement = minerMovement[move];

                            if (currMovement == "up")
                            {
                                if (lastRow - 1 >= 0 && lastRow - 1 < fieldSize)
                                {
                                    lastRow = lastRow - 1;

                                    if (field[lastRow, lastCol] == 'e')
                                    {
                                        isEnd = true;
                                        break;
                                    }
                                    else if (field[lastRow, lastCol] == 'c')
                                    {
                                        //It is a coal
                                        //We will collect it and replace it with '*'
                                        field[lastRow, lastCol] = '*';
                                    }
                                }
                            }
                            else if (currMovement == "down")
                            {
                                if (lastRow + 1 >= 0 && lastRow + 1 < fieldSize)
                                {
                                    lastRow = lastRow + 1;

                                    if (field[lastRow, lastCol] == 'e')
                                    {
                                        isEnd = true;
                                        break;
                                    }
                                    else if (field[lastRow, lastCol] == 'c')
                                    {
                                        //It is a coal
                                        //We will collect it and replace it with '*'
                                        field[lastRow, lastCol] = '*';
                                    }
                                }
                            }
                            else if (currMovement == "right")
                            {
                                if (lastCol + 1 >= 0 && lastCol + 1 < fieldSize)
                                {
                                    lastCol = lastCol + 1;

                                    if (field[lastRow, lastCol] == 'e')
                                    {
                                        isEnd = true;
                                        break;
                                    }
                                    else if (field[lastRow, lastCol] == 'c')
                                    {
                                        //It is a coal
                                        //We will collect it and replace it with '*'
                                        field[lastRow, lastCol] = '*';
                                    }
                                }
                            }
                            else if (currMovement == "left")
                            {
                                if (lastCol - 1 >= 0 && lastCol - 1 < fieldSize)
                                {
                                    lastCol = lastCol - 1;

                                    if (field[lastRow, lastCol] == 'e')
                                    {
                                        isEnd = true;
                                        break;
                                    }
                                    else if (field[lastRow, lastCol] == 'c')
                                    {
                                        //It is a coal
                                        //We will collect it and replace it with '*'
                                        field[lastRow, lastCol] = '*';
                                    }
                                }
                            }
                        }
                    }

                    if (isEnd)
                    {
                        break;
                    }
                }

                if (isEnd)
                {
                    break;
                }
            }

            if (isEnd)
            {
                Console.WriteLine($"Game over! ({lastRow}, {lastCol})");
            }
            else
            {
                int coalsLeft = 0;
                for (int row = 0; row < fieldSize; row++)
                {
                    for (int col = 0; col < fieldSize; col++)
                    {
                        if (field[row, col] == 'c')
                        {
                            coalsLeft++;
                        }
                    }
                }

                if (coalsLeft > 0)
                {
                    Console.WriteLine($"{coalsLeft} coals left. ({lastRow}, {lastCol})");
                }
                else
                {
                    Console.WriteLine($"You collected all coals! ({lastRow}, {lastCol})");
                }
            }
        }
    }
}
