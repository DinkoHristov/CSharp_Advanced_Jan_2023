using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> charCounter = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if (charCounter.ContainsKey(currChar))
                {
                    charCounter[currChar]++;
                }
                else
                {
                    charCounter.Add(currChar, 1);
                }
            }

            foreach (var currChar in charCounter
                .OrderBy(charSymb => charSymb.Key))
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }
    }
}
