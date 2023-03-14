using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string peopleInfo = string.Empty;
            while ((peopleInfo = Console.ReadLine()) != "END")
            {
                //"{name} {age} {town}"
                string[] personInfo = peopleInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person()
                {
                    Name = name,
                    Age = age,
                    Town = town
                };

                people.Add(person);
            }

            int personToSearch = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[personToSearch];

            int equalCount = 0;
            int differentCount = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
                else
                {
                    differentCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {differentCount} {people.Count}");
            }
        }
    }
}
