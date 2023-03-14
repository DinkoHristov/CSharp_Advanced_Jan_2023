using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine()); //In seconds
            int freeWindowDuration = int.Parse(Console.ReadLine()); //In seconds

            Queue<string> cars = new Queue<string>();
            bool isCrashed = false;
            int carsPassed = 0;
            int initialGreen = greenDuration;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {                
                if (command == "green")
                {
                    if (greenDuration == 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    while (cars.Count > 0 && initialGreen > 0)
                    {
                        int carLength = cars.Peek().Length;

                        if (carLength <= initialGreen)
                        {
                            //Passes successfully
                            carsPassed++;
                            initialGreen -= carLength;
                            cars.Dequeue();
                        }
                        else
                        {
                            if (carLength <= initialGreen + freeWindowDuration)
                            {
                                //Passed
                                carsPassed++;
                                cars.Dequeue();
                                break;
                            }
                            else
                            {
                                isCrashed = true;
                                Console.WriteLine("A crash happened!");
                                int indexCrashed = initialGreen + freeWindowDuration;
                                string carText = cars.Peek();
                                string subs = carText.Substring(indexCrashed, 1);
                                Console.WriteLine($"{carText} was hit at {subs}.");
                                return;
                            }
                        }
                    }

                    initialGreen = greenDuration;
                }
                else
                {
                    //It is a car if it is not "green"
                    cars.Enqueue(command);
                }
            }

            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
