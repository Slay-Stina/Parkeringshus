using System.Collections.Generic;

namespace Parkeringshus;

internal class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Parking parkinghouse = new Parking();

        while (true)
        {
            Console.WriteLine("1. Nytt fordon\t2. Checka ut");
            switch (Check.Bool())
            {
                case true:
                    Parking.NewVehicle(random.Next(3));
                    break;
                case false:
                    Parking.CheckOut();
                    break;
            }
            Console.Clear();
            Parking.SpaceList();
        }
    }
}
