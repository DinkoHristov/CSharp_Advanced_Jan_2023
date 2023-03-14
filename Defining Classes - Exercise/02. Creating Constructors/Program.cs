using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();

            Person personTwo = new Person(20);

            Person personThree = new Person("Ivan", 30);
        }
    }
}
