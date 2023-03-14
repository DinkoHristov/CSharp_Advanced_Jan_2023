using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textile = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> medicaments = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> healingItems = new Dictionary<string, int>()
            {
                { "Patch", 30},
                { "Bandage", 40},
                { "MedKit", 100}
            };

            Dictionary<string, int> createdItems = new Dictionary<string, int>();

            while (textile.Count > 0 && medicaments.Count > 0)
            {
                int currTextile = textile.Dequeue();
                int currMedicament = medicaments.Pop();

                int sum = currTextile + currMedicament;

                bool isItemFound = false;

                foreach (var item in healingItems
                    .Where(i => i.Value == sum))
                {
                    isItemFound = true;

                    if (!createdItems.ContainsKey(item.Key))
                    {
                        createdItems.Add(item.Key, 0);
                    }

                    createdItems[item.Key]++;
                }

                if (!isItemFound)
                {
                    if (sum > healingItems["MedKit"])
                    {
                        if (!createdItems.ContainsKey("MedKit"))
                        {
                            createdItems.Add("MedKit", 0);
                        }

                        createdItems["MedKit"]++;

                        int remainingSum = sum - healingItems["MedKit"];

                        int nextMedicament = 0;
                        if (medicaments.Count > 0)
                        {
                            nextMedicament = medicaments.Pop();
                        }

                        remainingSum += nextMedicament;
                        medicaments.Push(remainingSum);
                    }
                    else
                    {
                        currMedicament += 10;
                        medicaments.Push(currMedicament);
                    }
                }
            }

            bool areBothEmpty = false;
            if (textile.Count <= 0 && medicaments.Count <= 0)
            {
                areBothEmpty = true;
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            if (textile.Count <= 0 && !areBothEmpty)
            {
                Console.WriteLine("Textiles are empty.");
            }

            if (medicaments.Count <= 0 && !areBothEmpty)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            foreach (var item in createdItems
                .OrderByDescending(value => value.Value)
                .ThenBy(name => name.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textile.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
            }
        }
    }
}
