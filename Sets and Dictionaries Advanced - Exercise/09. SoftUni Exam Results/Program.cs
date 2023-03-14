using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> courses = new Dictionary<string, int>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] commandArgs = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                
                if (commandArgs.Length > 2)
                {
                    string studentName = commandArgs[0];
                    string courseName = commandArgs[1];
                    int points = int.Parse(commandArgs[2]);

                    if (students.ContainsKey(studentName))
                    {
                        int oldPoints = students[studentName];

                        if (points > oldPoints)
                        {
                            students[studentName] = points;
                        }
                    }
                    else
                    {
                        students.Add(studentName, points);
                    }

                    if (courses.ContainsKey(courseName))
                    {
                        courses[courseName]++;
                    }
                    else
                    {
                        courses.Add(courseName, 1);
                    }
                }
                else
                {
                    //Student name is
                    string studentName = commandArgs[0];
                    if (students.ContainsKey(studentName))
                    {
                        students.Remove(studentName);
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var student in students
                .OrderByDescending(points => points.Value)
                .ThenBy(name => name.Key))
            {
                string name = student.Key;
                int points = student.Value;

                Console.WriteLine($"{name} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var course in courses
                .OrderByDescending(count => count.Value)
                .ThenBy(name => name.Key))
            {
                string name = course.Key;
                int count = course.Value;

                Console.WriteLine($"{name} - {count}");
            }
        }
    }
}
