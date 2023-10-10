using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace övning5
{
    //Logic and works with the garage
    internal class Handler
    {
        private IGarage<Vehicle> garage;
        private bool foundMatch;

        public Handler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        internal bool Park(Vehicle ParkVehicle)
        {
            return garage.Park(ParkVehicle);

        }
        internal Vehicle FindVehicle(string regNo)
        {
            foreach (var v in garage)
            {
                if (v.registrationNumber == regNo)
                {
                    return v; //Or just return a string to display in manger
                }
            }
            return null;

            //Same as above!!!!!

           // return garage.FirstOrDefault(v => v.registrationNumber == regNo);
        }


        //I should do these:
        //1: List all vehicles
        //2: Implement functionality to remove 
        //3: Implement functionality to find specific vehicle
        //4: Search for specific information

        public void ListOfVehicles()
        {
            foreach (var v in garage)
            {
                Console.WriteLine($"{v.GetType().Name} - Registration number: {v.registrationNumber}");
            }
        }

        public void ParkVehicle()
        {

            while (true)
            {

                Console.WriteLine("Choose a vehicle to park:");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Motorcycle");
                Console.WriteLine("3.Boat");
                Console.WriteLine("4.Buss");
                Console.WriteLine("5.Airplane");
                Console.WriteLine("6. Search based on red color! ");
                Console.WriteLine("7. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {




                    string name = string.Empty;
                    string regnumber = string.Empty;
                    string color = string.Empty;
                    int wheels = 0;



                    if (choice != 7 && choice != 6)
                    {
                        Console.WriteLine("Enter the vehicle name:");
                        name = Console.ReadLine()!;
                        Console.WriteLine("Enter Registration number:");
                        regnumber = Console.ReadLine()!;
                        Console.WriteLine("Enter color:");
                        color = Console.ReadLine()!;
                       
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter fuel type:");
                            string fueltype = Console.ReadLine()!;// we put ! to say we know that it is not null:// i want to come back to previous menue
                            Console.WriteLine("Enter the number of wheels: ");
                            if (!int.TryParse(Console.ReadLine(), out wheels))
                            {
                                Console.WriteLine("Invalid imput for number of wheels!");
                                return;
                            }

                            Car car = new Car(color, regnumber, wheels, name, fueltype);
                            garage.Park(car);
                            Console.WriteLine($"{car.registrationNumber}has been parked to the parking");
                            
                            

                            break;// when i want to exit this exit does not work





                        case 2:

                            Console.WriteLine("Enter cylinder volume: ");

                            if (!int.TryParse(Console.ReadLine(), out int cylinder))
                            {
                                Console.WriteLine("Invalid input for cylinder size");
                                return;
                            }
                            Console.WriteLine("Enter number of wheels:");
                            if (!int.TryParse(Console.ReadLine(), out wheels))
                            {
                                Console.WriteLine("Invalid imput for number of wheels!");
                                return;
                            }
                            Motorcycle motorcycle = new Motorcycle(color, regnumber, wheels, name, cylinder);
                            garage.Park(motorcycle);
                            Console.WriteLine($"{motorcycle.registrationNumber}has been parked to the parking");
                           
                            break;




                        case 3:
                            Console.WriteLine("Enter the lenght of boat");

                            if (!int.TryParse(Console.ReadLine(), out int lenght))
                            {
                                Console.WriteLine("Invalid input for cylinder size");
                                return;
                            }

                            Boat boat = new Boat(color, regnumber, wheels, name, lenght);
                            garage.Park(boat);
                            Console.WriteLine($"{boat.registrationNumber}has been parked to the parking");
                            break;


                        case 4:
                             
                            if (!int.TryParse(Console.ReadLine(), out int numberOfSeats))
                            {
                                Console.WriteLine("Invalid input for cylinder size");
                                return;
                            }
                            Console.WriteLine("Enter number of wheels:");
                            if (!int.TryParse(Console.ReadLine(), out wheels))
                            {
                                Console.WriteLine("Invalid imput for number of wheels!");
                                return;
                            }
                            Buss buss = new Buss(color, regnumber, wheels, name, numberOfSeats);
                            garage.Park(buss);
                            Console.WriteLine($"{buss.registrationNumber}has been parked to the parking");
                           
                            break;


                        case 5:
                            Console.WriteLine("Enter the number of engines: ");
                            if (!int.TryParse(Console.ReadLine(), out int numberOfEngine))
                            {
                                Console.WriteLine("Invalid input for cylinder size");
                                return;
                            }
                            Airplane airplane = new Airplane(color, regnumber, wheels, name, numberOfEngine);
                            garage.Park(airplane);
                            Console.WriteLine($"{airplane.registrationNumber}has been parked to the parking");
                            break;
                        case 6:
                            Console.WriteLine("Search for all cars that have a red color");
                            VehicleSearchDTO vehicleSearchDTO = new VehicleSearchDTO();
                            vehicleSearchDTO.color = color;
                            vehicleSearchDTO.name = name;
                            vehicleSearchDTO.wheels = wheels;
                           

                            IEnumerable<Vehicle> serachRe = Search2(vehicleSearchDTO);
                            
                            foreach (Vehicle v in serachRe) {
                                Console.WriteLine($"There is a {v.GetType().Name} with following information in list.");
                            }


                            break;
                      

                        case 7:
                            return;                            
                       
                }


                }
            }

        }

        internal string CheckOut(string regNo)
        {

            //Get the Vehicle
            Vehicle v = FindVehicle(regNo);


            //Get any result? 
            if (v != null)
            {
                Console.WriteLine($"This is the find car: {v.name}");
                //Act
                garage.Remove(v);
                return ($"The vehicle with {v.registrationNumber} has been checked out!");
            }
            else {
                //Send information to display to the user if ok!
                return ($"The vehicle does not exist inthe parking list yet!"); }

        }


        public void SearchOnRegNo(string registrationNumber)
        {
            //Search on regNo!
            //1. ask the user for reg number
            //2. pass it to handler


            // 3.Act on result
            if (isRegCorrect(registrationNumber))
            {
                //4. Write to Console
                Vehicle result = FindVehicle(registrationNumber);
                if (result != null)
                {
                    Console.WriteLine($"Your vehicle {result.name} exist in the parking list");
                }
                else {
                    Console.WriteLine($"Your registration number does not exist in the parkring list!");
                }

            }



        }






        private bool isRegCorrect(string regNo)
        {
            //Console.WriteLine($"#isRegCorrect registration number is {regNo}");
            string pattern = "^[A-Za-z]{3}\\d{3}$";
            bool isMatch = Regex.IsMatch(regNo, pattern);
            //Console.WriteLine($"#isRegCorrect return  {isMatch}");
            return isMatch;

        }
        public void SearchVehiclesByspecific(int weels, string color)
        {
            foreach (var v in garage)
            {
                if (v.color == color && v.numberOfWheels == 4)
                {
                    Console.WriteLine($"Your registration number does not exist in the parkring list!");
                }
                else {
                    Console.WriteLine($"There is not any vehichel with folowing proprties in the list!");
                }
            }                                                                                                                                                   


        }

        public IEnumerable<Vehicle> Search(VehicleSearchDTO dto)
        {
            IEnumerable<Vehicle> result = nameof(Car) == "red" ? garage : garage.Where(v => v.GetType() == typeof(Car));

            if (string.IsNullOrEmpty(dto.color))

            {
                Console.WriteLine($"inside if condition ****** {dto.color} !");
                result = result.Where(v => v.color == dto.color);
               
            }


         

            return result;
        }

        public IEnumerable<Vehicle> Search2(VehicleSearchDTO dto) {

            string targetColor = "red"; // Replace "red" with the desired color to filter by
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle vehicle in garage)
            {
                if (vehicle.color == targetColor && vehicle.GetType() == typeof(Car))
                {
                    result.Add(vehicle);
                }

            }

            return result;
        }
        public IEnumerable<Vehicle> Search3(VehicleSearchDTO dto)
        {

            int targetwheels = 4; // Replace "red" with the desired color to filter by
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle vehicle in garage)
            {
                if (vehicle.numberOfWheels == targetwheels)
                {
                    result.Add(vehicle);
                }

            }

            return result;
        }


    }

}


        








    