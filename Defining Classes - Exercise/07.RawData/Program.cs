using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
                //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}
                //{tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tireOnePressure = double.Parse(carInfo[5]);
                int tireOneAge = int.Parse(carInfo[6]);
                double tireTwoPressure = double.Parse(carInfo[7]);
                int tireTwoAge = int.Parse(carInfo[8]);
                double tireThreePressure = double.Parse(carInfo[9]);
                int tireThreeAge = int.Parse(carInfo[10]);
                double tireFourPressure = double.Parse(carInfo[11]);
                int tireFourAge = int.Parse(carInfo[12]);

                Engine engine = new Engine()
                {
                    Speed = engineSpeed,
                    Power = enginePower
                };
                Cargo cargo = new Cargo()
                { 
                    Weight = cargoWeight,
                    Type = cargoType
                };
                Tires tireOne = new Tires()
                { 
                    Age = tireOneAge,
                    Pressure = tireOnePressure
                };
                Tires tireTwo = new Tires()
                {
                    Age = tireTwoAge,
                    Pressure = tireTwoPressure
                };
                Tires tireThree = new Tires()
                {
                    Age = tireThreeAge,
                    Pressure = tireThreePressure
                };
                Tires tireFour = new Tires()
                {
                    Age = tireFourAge,
                    Pressure = tireFourPressure
                };

                Car car = new Car(model, engine, cargo, tireOne, tireTwo, tireThree, tireFour);
                cars.Add(car);
            }

            string command = Console.ReadLine(); //"fragile" or "flammable"

            if (command == "fragile")
            {
                foreach (Car car in cars
                    .Where(car => car.Cargo.Type == "fragile")
                    .Where(pressure => (pressure.TireOne.Pressure < 1) ||
                    (pressure.TireTwo.Pressure < 1) || (pressure.TireThree.Pressure < 1) ||
                    (pressure.TireFour.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (Car car in cars
                    .Where(car => car.Cargo.Type == "flammable")
                    .Where(car => car.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
