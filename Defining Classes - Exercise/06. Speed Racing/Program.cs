using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, car);
                }
            }

            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                //"Drive {carModel} {amountOfKm}"
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = commandArgs[1];
                double travelAmount = double.Parse(commandArgs[2]);

                if (cars.ContainsKey(model))
                {
                    cars[model].CalculateFuel(cars[model], travelAmount);
                }
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}
