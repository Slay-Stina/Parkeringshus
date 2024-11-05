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
            Parking.SpaceList();
            Console.WriteLine("1. Nytt fordon\t2. Checka ut");
            switch (Check.Bool())
            {
                case true:
                    Parking.NewVehicle(random.Next(3)); 
                    break;
                case false:
                    Check.Out();
                    break;
            }
            Console.Clear();
        }
    }
}
