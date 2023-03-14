using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tires tireOne, Tires tireTwo, Tires tireThree, Tires tireFour)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.TireOne = tireOne;
            this.TireTwo = tireTwo;
            this.TireThree = tireThree;
            this.TireFour = tireFour;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires TireOne { get; set; }
        public Tires TireTwo { get; set; }
        public Tires TireThree { get; set; }
        public Tires TireFour { get; set; }
    }
}
