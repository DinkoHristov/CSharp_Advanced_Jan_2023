using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = 
                new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                //"{color} -> {item1},{item2},{item3}…"
                string[] currColor = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = currColor[0];
                string[] dresses = currColor[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(colour))
                {
                    for (int d = 0; d < dresses.Length; d++)
                    {
                        string currDress = dresses[d];

                        if (wardrobe[colour].ContainsKey(currDress))
                        {
                            wardrobe[colour][currDress]++;
                        }
                        else
                        {
                            wardrobe[colour].Add(currDress, 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());

                    for (int d = 0; d < dresses.Length; d++)
                    {
                        string currDress = dresses[d];

                        if (wardrobe[colour].ContainsKey(currDress))
                        {
                            wardrobe[colour][currDress]++;
                        }
                        else
                        {
                            wardrobe[colour].Add(currDress, 1);
                        }
                    }
                }
            }

            string[] searchedDressInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string color = searchedDressInfo[0];
            string dress = searchedDressInfo[1];

            foreach (var currDress in wardrobe)
            {
                string currColor = currDress.Key;

                Console.WriteLine($"{currColor} clothes:");
                foreach (var dressColor in currDress.Value)
                {
                    string currDressName = dressColor.Key;
                    int timesMet = dressColor.Value;

                    if (currColor == color && currDressName == dress)
                    {
                        Console.WriteLine($"* {currDressName} - {timesMet} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currDressName} - {timesMet}");
                    }
                }
            }
        }
    }
}
