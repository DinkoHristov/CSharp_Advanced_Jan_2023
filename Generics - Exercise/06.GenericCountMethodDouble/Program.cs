using System;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Box<double> boxes = new Box<double>();

            for (int i = 0; i < count; i++)
            {
                double number = double.Parse(Console.ReadLine());

                boxes.Add(number);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(boxes.Count(itemToCompare));
        }
    }
}
