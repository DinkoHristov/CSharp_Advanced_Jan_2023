using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int intelligence = int.Parse(Console.ReadLine());

            int initialBulletsCount = bullets.Count;
            int currentBarrelSize = barrelSize;

            for (int i = 0; i < initialBulletsCount; i++)
            {

                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                currentBarrelSize--;

                if (currentBarrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentBarrelSize = barrelSize;
                }

                if (!bullets.Any() && locks.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                if (!locks.Any())
                {
                    int moneyEarned = intelligence - (initialBulletsCount - bullets.Count) * bulletPrice;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    return;
                }
            }
        }
    }
}
