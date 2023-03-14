using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> invitedPeople = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = 
                new Dictionary<string, Predicate<string>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];
                string filterType = commandArgs[1];
                string filterValue = commandArgs[2];

                if (commandType == "Add filter")
                {
                    filters.Add(filterType + filterValue ,GetPredicates(filterType, filterValue));
                }
                else if (commandType == "Remove filter")
                {
                    filters.Remove(filterType + filterValue);
                }
            }

            foreach (var filter in filters)
            {
                invitedPeople.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", invitedPeople));
        }

        public static Predicate<string> GetPredicates(string filterType, string filterValue)
        {
            if (filterType == "Starts with")
            {
                return people => people.StartsWith(filterValue);
            }
            else if (filterType == "Ends with")
            {
                return people => people.EndsWith(filterValue);
            }
            else if (filterType == "Length")
            {
                return people => people.Length == int.Parse(filterValue);
            }
            else if (filterType == "Contains")
            {
                return people => people.Contains(filterValue);
            }

            return default;
        }
    }
}
