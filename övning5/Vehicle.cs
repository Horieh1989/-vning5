using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace övning5
{
    public class Vehicle : IVehicle

    {
        public string registrationNumber { get; set; }
        public string color { get; set; }
        public int numberOfWheels { get; set; }
        public string name { get; set; }
        public Vehicle(string color, string registrationNumber, int numberOfWheels, string name)
        {
            this.color = color;
            this.registrationNumber = registrationNumber;
            this.numberOfWheels = numberOfWheels;
            this.name = name;
        }
    }
    class Car : Vehicle
    {
        public string FuelType { get; set; }
        public Car(string color, string registrationNumber, int numberOfWheels, string name, string fuelType) : base(color, registrationNumber, numberOfWheels, name)
        {
            this.color = color;

            FuelType = fuelType;
        }

    }
    class Motorcycle : Vehicle

    {
        public int cylinderValume { get; set; }


        public Motorcycle(string color, string registrationNumber, int numberOfWheels, string name, int cylinderValume) : base(color, registrationNumber, numberOfWheels, name)
        {
            this.cylinderValume = cylinderValume;
        }

    }
    class Boat : Vehicle
    {
        public int lenght { get; set; }
        public Boat(string color, string registrationNumber, int numberOfWheels, string name,int lenght) : base(color, registrationNumber, numberOfWheels, name)
        {
            this.lenght = lenght;
        }
    }
    class Airplane : Vehicle
    {
        public int numberOfEngine { get; set; }
        public Airplane(string color, string registrationNumber, int numberOfWheels, string name,int numberOfEngine) : base(color, registrationNumber, numberOfWheels, name)
        {
            this.numberOfEngine = numberOfEngine;
        }
    }
    class Buss : Vehicle
    {  
        public int numberOfSeats { get; set; }
        public Buss(string color, string registrationNumber, int numberOfWheels, string name,int numberOfseats) : base(color, registrationNumber, numberOfWheels, name)
        {
            this.numberOfSeats = numberOfseats;
        }
    }
}   
