using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public void ToString(Car car)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($" {car.Engine.Model}:");
            Console.WriteLine($"  Power: {car.Engine.Power}");
            if (car.Engine.Displacement == 0)
            {
                Console.WriteLine($"  Displacement: n/a");
            }
            else
            {
                Console.WriteLine($"  Displacement: {car.Engine.Displacement}");
            }
            if (car.Engine.Efficiency == string.Empty)
            {
                Console.WriteLine($"  Efficiency: n/a");
            }
            else
            {
                Console.WriteLine($"  Efficiency: {car.Engine.Efficiency}");
            }
            if (car.Weight == 0)
            {
                Console.WriteLine($" Weight: n/a");
            }
            else
            {
                Console.WriteLine($" Weight: {car.Weight}");
            }
            if (car.Color == string.Empty)
            {
                Console.WriteLine($" Color: n/a");
            }
            else
            {
                Console.WriteLine($" Color: {car.Color}");
            }
        }
    }
}
