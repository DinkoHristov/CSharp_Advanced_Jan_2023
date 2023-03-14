using System;
using System.Collections.Generic;

namespace _08._Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                //"{model} {power} {displacement} {efficiency}" -> 2nd two could be missing
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInfo[0];
                int enginePower = int.Parse(engineInfo[1]);
                int displacement = 0;
                string efficiency = string.Empty;

                if (engineInfo.Length == 3 && char.IsDigit(engineInfo[2][0]))
                {
                    displacement = int.Parse(engineInfo[2]);
                }
                else if (engineInfo.Length == 3 && char.IsLetter(engineInfo[2][0]))
                {
                    efficiency = engineInfo[2];
                }
                else if (engineInfo.Length == 4)
                {
                    displacement = int.Parse(engineInfo[2]);
                    efficiency = engineInfo[3];
                }

                Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
                engines.Add(engineModel, engine);
            }

            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                //"{model} {engine} {weight} {color}". -> 2nd two could be missing
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];
                int weight = 0;
                string color = string.Empty;

                if (carInfo.Length == 3 && char.IsDigit(carInfo[2][0]))
                {
                    weight = int.Parse(carInfo[2]);
                }
                else if (carInfo.Length == 3 && char.IsLetter(carInfo[2][0]))
                {
                    color = carInfo[2];
                }
                else if (carInfo.Length == 4)
                {
                    weight = int.Parse(carInfo[2]);
                    color = carInfo[3];
                }

                Car car = new Car(model, engines[engineModel], weight, color);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                car.ToString(car);
            }
        }
    }
}
