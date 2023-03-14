using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] commandArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string course = commandArgs[0];
                string password = commandArgs[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, password);
                }
            }

            Dictionary<string, Dictionary<string, int>> students = 
                new Dictionary<string, Dictionary<string, int>>();

            command = string.Empty;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] commandArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string course = commandArgs[0];
                string password = commandArgs[1];
                string student = commandArgs[2];
                int points = int.Parse(commandArgs[3]);

                if (courses.ContainsKey(course))
                {
                    //If course exists, check the given password
                    if (courses[course] == password)
                    {
                        if (students.ContainsKey(student))
                        {
                            if (students[student].ContainsKey(course))
                            {
                                int oldPoints = students[student][course];

                                if (points > oldPoints)
                                {
                                    students[student][course] = points;
                                }
                            }
                            else
                            {
                                students[student].Add(course, points);
                            }
                        }
                        else
                        {
                            students.Add(student, new Dictionary<string, int>());
                            students[student].Add(course, points);
                        }
                    }
                }
            }

            string bestCandidate = string.Empty;
            int bestPoints = int.MinValue;
            foreach (var student in students)
            {
                int currPoints = 0;
                foreach (var point in student.Value)
                {
                    currPoints += point.Value;
                }

                if (currPoints > bestPoints)
                {
                    bestCandidate = student.Key;
                    bestPoints = currPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students
                .OrderBy(name => name.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var course in student.Value
                    .OrderByDescending(point => point.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
