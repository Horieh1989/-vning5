using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace övning5
{
    //Stores vehicles
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] vehicles;
        public readonly int Capacity;
        private readonly object Vehicles;
        private int count;


        public Garage(int capacity)
        {
            //Validate capacity before try to instanciate array
            this.Capacity = capacity;
            this.vehicles = new T[capacity];
           
        }


        public bool Park(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is null)
                {
                    vehicles[i] = vehicle;

                    return true;
                }
            }
            return false;
        }




        public void Remove(T vehicle)
        {

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == vehicle)
                {
                    List<T> tmp = new(vehicles);
                    tmp.RemoveAt(i);
                    vehicles = tmp.ToArray();

                }

            }

        }
        public int Totalpark(T Vehicle)// we calculate the numbers of parked cars in garage.
        {
            count = vehicles.Length;

            if (count < Capacity)
            {
                int avalableplace = count - Capacity;

                Console.WriteLine("Avalable place: " + avalableplace);
            }
            else if (count == Capacity)
            {
                Console.WriteLine("parking is full! ");
            }
            return count;
        }
        public void ListOfVehicles(T Vehicle)
        {

            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine($" Vehicle information:{vehicle} +   + {Totalpark} ");
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)// or i should just return it?
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
