using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace övning5
{
    //Menys and take input and output from UI
    internal class Manager
    {
        private Handler handler;
        private ConsoleUI ui;

        public Manager()
        {
            handler = new Handler(10);
            ui = new ConsoleUI();
        }

        internal void Run()
        {

            //AskFor Capacity

            //ShowMainMeny

            //Act

            while (true)
            {
                ui.Print("Chose one option: ");
                Console.WriteLine("1.Park car");
                Console.WriteLine("2.Search on Register number");
                Console.WriteLine("3.List of all cars ");
                Console.WriteLine("4.check out vehicle :");
               
                Console.WriteLine("5.Exit");

                if (int.TryParse(Console.ReadLine(), out int choice)) ;//i return the string to the int and,take it with out and put it in choice
                switch (choice)
                {
                    case 1:

                        handler.ParkVehicle();
                        break;
                    case 2:
                        // search on regNo?
                        //ask ¨the user for reg number
                        Console.WriteLine("enter your vehicle registration number: ");
                        string registrationNumber = Console.ReadLine()!;
                        handler.SearchOnRegNo(registrationNumber);
                        // var result2 = handler.CheckOut(regNo);
                        //Write to console
                        break;
                       
                    case 3:
                        handler.ListOfVehicles(); //how user use this when we have nothing into our list?

                        break;
                    case 4:

                        Console.WriteLine("enter your vehicle registration number: ");
                        string regNumber = Console.ReadLine()!;
                        //change method return to
                        String checkOut =handler.CheckOut(regNumber);
                        Console.WriteLine(checkOut);
                        // search on regNumber
                        //ask 
                        //Console.WriteLine(  "Enter your registraition number: ");
                        //string v = Console.ReadLine()!;
                        //handler.CheckOut (v );

                        break;

                    //case 5:
                    //    Console.WriteLine(  "Enter the color of vehicle: ");
                    //    string color=Console.ReadLine()!;
                    //    handler.searchOnColor(color );
                    //    break;
                    //case 6:
                    //    Console.WriteLine( "Enter the color: ");
                    //    string c=Console.ReadLine()!;
                    //    Console.WriteLine(  "Enter the number of wheels: ");
                    //    if (!int.TryParse(Console.ReadLine(), out int w))
                    //    handler.SearchVehiclesByspecific(w, c);
                    //    break;


                    case 5:
                        Environment.Exit(0);

                        break;
                    default:

                        Console.WriteLine(" you add the wrong option! Enter between 1,2,3 options. ");
                        break;
                }

            }
        }

        
    }    
}