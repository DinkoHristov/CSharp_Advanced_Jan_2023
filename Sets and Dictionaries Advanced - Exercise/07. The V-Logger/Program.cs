using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                string type = commandArgs[1];

                if (type == "joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers.Add(name, new Dictionary<string, HashSet<string>>());
                        vloggers[name].Add("followers", new HashSet<string>());
                        vloggers[name].Add("following", new HashSet<string>());
                    }
                }
                else if (type == "followed")
                {
                    string firstVlogger = name;
                    string secondVlogger = commandArgs[2];

                    if (vloggers.ContainsKey(firstVlogger) &&
                        vloggers.ContainsKey(secondVlogger) &&
                        firstVlogger != secondVlogger)
                    {
                        vloggers[secondVlogger]["followers"].Add(firstVlogger);
                        vloggers[firstVlogger]["following"].Add(secondVlogger);
                    }
                }
            }

            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            foreach (var vlogger in vloggers
                .OrderByDescending(followers => followers.Value["followers"].Count)
                .ThenBy(following => following.Value["following"].Count))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                    foreach (string name in vlogger.Value["followers"]
                        .OrderBy(name => name))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                }

                count++;
            }
        }
    }
}
