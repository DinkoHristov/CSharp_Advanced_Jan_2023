using System;
using System.Linq;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSides = int.Parse(Console.ReadLine());

            char[,] chessTable = new char[boardSides, boardSides];
            for (int i = 0; i < boardSides; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currChessRow = input[0];

                for (int j = 0; j < currChessRow.Length; j++)
                {
                    chessTable[i, j] = currChessRow[j];
                }
            }

            int removedKnights = 0;
            for (int row = 0; row < boardSides; row++)
            {
                for (int col = 0; col < boardSides; col++)
                {
                    char knight = chessTable[row, col];

                    if (knight == 'K')
                    {
                        int knightRow = row;
                        int knightCol = col;
                        //It is knight
                        if ((knightCol - 2 >= 0 && knightCol - 2 < boardSides) &&
                            (knightRow - 1 >= 0 && knightRow - 1 < boardSides))
                        {
                            //2 left and 1 up
                            char figure = chessTable[row - 1, col - 2];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row - 1, col - 2] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightCol - 2 >= 0 && knightCol - 2 < boardSides) &&
                            (knightRow + 1 >= 0 && knightRow + 1 < boardSides))
                        {
                            //2 left and 1 down
                            char figure = chessTable[row + 1, col - 2];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row + 1, col - 2] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightCol + 2 >= 0 && knightCol + 2 < boardSides) &&
                            (knightRow - 1 >= 0 && knightRow - 1 < boardSides))
                        {
                            //2 right and 1 up
                            char figure = chessTable[row - 1, col + 2];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row - 1, col + 2] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightCol + 2 >= 0 && knightCol + 2 < boardSides) &&
                            (knightRow + 1 >= 0 && knightRow + 1 < boardSides))
                        {
                            //2 right and 1 down
                            char figure = chessTable[row + 1, col + 2];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row + 1, col + 2] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightRow - 2 >= 0 && knightRow - 2 < boardSides) &&
                            (knightCol - 1 >= 0 && knightCol - 1 < boardSides))
                        {
                            //2 up and 1 left
                            char figure = chessTable[row - 2, col - 1];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row - 2, col - 1] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightRow + 2 >= 0 && knightRow + 2 < boardSides) &&
                            (knightCol - 1 >= 0 && knightCol - 1 < boardSides))
                        {
                            //2 down and 1 left
                            char figure = chessTable[row + 2, col - 1];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row + 2, col - 1] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightRow - 2 >= 0 && knightRow - 2 < boardSides) &&
                            (knightCol + 1 >= 0 && knightCol + 1 < boardSides))
                        {
                            //2 up and 1 right
                            char figure = chessTable[row - 2, col + 1];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row - 2, col + 1] = '0';
                                removedKnights++;
                            }
                        }
                        if ((knightRow + 2 >= 0 && knightRow + 2 < boardSides) &&
                            (knightCol + 1 >= 0 && knightCol + 1 < boardSides))
                        {
                            //2 down and 1 right
                            char figure = chessTable[row + 2, col + 1];

                            if (figure == 'K')
                            {
                                //It's another knight
                                chessTable[row + 2, col + 1] = '0';
                                removedKnights++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(removedKnights);
        }
    }
}
