using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();

                usernames.Add(name);
            }

            foreach (string name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
