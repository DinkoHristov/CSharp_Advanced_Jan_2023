using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];

                if (commandType == "Double")
                {
                    string boundType = commandArgs[1];
                    
                    if (boundType == "Length")
                    {
                        int length = int.Parse(commandArgs[2]);

                        Predicate<string> filter = name => name.Length == length;

                        List<string> addPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < addPeople.Count; i++)
                        {
                            people.Add(addPeople[i]);
                        }
                    }
                    else if (boundType == "StartsWith")
                    {
                        string lettersToRemove = commandArgs[2];

                        Predicate<string> filter = name => name.StartsWith(lettersToRemove);

                        List<string> addPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < addPeople.Count; i++)
                        {
                            people.Add(addPeople[i]);
                        }
                    }
                    else if (boundType == "EndsWith")
                    {
                        string lettersToRemove = commandArgs[2];

                        Predicate<string> filter = name => name.EndsWith(lettersToRemove);

                        List<string> addPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < addPeople.Count; i++)
                        {
                            people.Add(addPeople[i]);
                        }
                    }
                }
                else if (commandType == "Remove")
                {
                    string boundType = commandArgs[1];

                    if (boundType == "Length")
                    {
                        int length = int.Parse(commandArgs[2]);

                        Predicate<string> filter = name => name.Length == length;

                        List<string> removedPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < removedPeople.Count; i++)
                        {
                            people.Remove(removedPeople[i]);
                        }
                    }
                    else if (boundType == "StartsWith")
                    {
                        string lettersToRemove = commandArgs[2];

                        Predicate<string> filter = name => name.StartsWith(lettersToRemove);

                        List<string> removedPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < removedPeople.Count; i++)
                        {
                            people.Remove(removedPeople[i]);
                        }
                    }
                    else if (boundType == "EndsWith")
                    {
                        string lettersToRemove = commandArgs[2];


                        Predicate<string> filter = name => name.EndsWith(lettersToRemove);

                        List<string> removedPeople = people.Where(name => filter(name)).ToList();

                        for (int i = 0; i < removedPeople.Count; i++)
                        {
                            people.Remove(removedPeople[i]);
                        }
                    }
                }
            }

            if (people.Count > 0)
            {
                List<string> orderedPeople = new List<string>();
                int index = 0;

                foreach (string name in people)
                {
                    if (orderedPeople.Contains(name))
                    {
                        index = people.IndexOf(name);
                        orderedPeople.Insert(index + 1, name);
                    }
                    else
                    {
                        orderedPeople.Add(name);
                    }
                }

                Console.WriteLine($"{string.Join(", ", orderedPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
