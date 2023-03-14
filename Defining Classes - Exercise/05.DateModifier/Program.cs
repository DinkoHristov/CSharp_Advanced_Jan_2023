using System;

namespace _05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int differenceInDays = DateModifier.CalculateDaysDifference(firstDate, secondDate);

            Console.WriteLine(differenceInDays);
        }
    }
}
