using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TraveledDistance = 0;
        }

        public string Model { get { return this.model; } set { this.model = value; } }
        public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }
        public double FuelConsumptionPerKilometer { get { return this.fuelConsumptionPerKilometer; } set { this.fuelConsumptionPerKilometer = value; } }
        public double TraveledDistance { get { return this.traveledDistance; } set { this.traveledDistance = value; } }

        public void CalculateFuel(Car car, double distance)
        {
            double neededFuel = distance * fuelConsumptionPerKilometer;
            if (neededFuel <= car.FuelAmount)
            {
                car.FuelAmount -= neededFuel;
                car.TraveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
