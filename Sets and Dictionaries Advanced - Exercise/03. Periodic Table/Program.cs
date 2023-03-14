using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> chemicalElements = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string[] chemicalElementArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < chemicalElementArray.Length; j++)
                {
                    string currElement = chemicalElementArray[j];

                    chemicalElements.Add(currElement);
                }
            }

            foreach (string currElement in chemicalElements
                .OrderBy(e => e))
            {
                Console.Write(currElement + " ");
            }
        }
    }
}
