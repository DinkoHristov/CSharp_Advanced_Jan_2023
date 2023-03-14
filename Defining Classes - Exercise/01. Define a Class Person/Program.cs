using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person ivan = new Person()
            { 
                Name = "Ivan",
                Age = 20
            };

            Person peter = new Person()
            { 
                Name = "Peter",
                Age = 30
            };

            Console.WriteLine($"{ivan.Name} is {ivan.Age} years old.");
            Console.WriteLine($"{peter.Name} is {peter.Age} years old.");
        }
    }
}
