using System;

namespace _02.GenericBoxofInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                Box<int> intBox = new Box<int>(number);

                Console.WriteLine(intBox.ToString());
            }
        }
    }
}
