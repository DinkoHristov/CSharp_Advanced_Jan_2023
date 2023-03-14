using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> users =
                new Dictionary<string, HashSet<string>>();

            HashSet<string> existingUsers = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    CheckAndAddForceUser(input, users, existingUsers);
                }
                else if (input.Contains("->"))
                {
                    //{forceUser} -> {forceSide}
                    string[] inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = inputArgs[0];
                    string forceSide = inputArgs[1];

                    //Check if there is such a forceUser already and if so,
                    //  -> change his/her side.
                    if (existingUsers.Contains(forceUser))
                    {
                        string oldSide = SearchForSide(forceUser, forceSide, users);

                        if (users.ContainsKey(forceSide) && forceSide != oldSide)
                        {
                            users[forceSide].Add(forceUser);
                            users[oldSide].Remove(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                        else if (!users.ContainsKey(forceSide) && forceSide != oldSide)
                        {
                            users.Add(forceSide, new HashSet<string>());
                            users[forceSide].Add(forceUser);
                            users[oldSide].Remove(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                    }
                    //If there is no such forceUser,
                    //add him/her to the corresponding forceSide,
                    //treating the command as a newly registered forceUser.
                    else
                    {
                        if (users.ContainsKey(forceSide))
                        {
                            users[forceSide].Add(forceUser);
                            existingUsers.Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                        else
                        {
                            users.Add(forceSide, new HashSet<string>());
                            users[forceSide].Add(forceUser);
                            existingUsers.Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                    }
                }
            }

            PrintForceUsers(users);
        }

        public static void CheckAndAddForceUser(string input, Dictionary<string, HashSet<string>> users, HashSet<string> existingUsers)
        {
            //{forceSide} | {forceUser}
            string[] inputArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            string forceSide = inputArgs[0];
            string forceUser = inputArgs[1];

            //If such forceUser already exists, if NOT add him to the given side 
            if (users.ContainsKey(forceSide))
            {
                if (!users[forceSide].Contains(forceUser) && !existingUsers.Contains(forceUser))
                {
                    users[forceSide].Add(forceUser);
                    existingUsers.Add(forceUser);
                }
            }
            else
            {
                if (!existingUsers.Contains(forceUser))
                {
                    users.Add(forceSide, new HashSet<string>());
                    users[forceSide].Add(forceUser);
                    existingUsers.Add(forceUser);
                }
            }
        }

        public static string SearchForSide(string forceUser, string forceSide, Dictionary<string, HashSet<string>> users)
        {
            string oldSide = string.Empty;
            bool isSideFound = false;

            foreach (var side in users)
            {
                foreach (var user in side.Value)
                {
                    if (user == forceUser)
                    {
                        oldSide = side.Key;
                        return oldSide;
                    }
                }
            }

            return string.Empty;
        }

        public static void PrintForceUsers(Dictionary<string, HashSet<string>> users)
        {
            foreach (var side in users
                .OrderByDescending(count => count.Value.Count)
                .ThenBy(name => name.Key)
                .Where(x => x.Value.Count > 0))
            {
                string currSide = side.Key;
                int currSideCount = side.Value.Count;
                Console.WriteLine($"Side: {currSide}, Members: {currSideCount}");

                foreach (var user in side.Value
                    .OrderBy(name => name))
                {
                    string currName = user;

                    Console.WriteLine($"! {currName}");
                }
            }
        }
    }
}
