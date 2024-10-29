using System.Collections.Generic;

namespace Parkeringshus;

internal class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<Parking> parkingHouse = new List<Parking>();
        for (int i = 0; i < 15; i++)
        {
            parkingHouse.Add(new Parking());
        }
        while (true)
        {
            Parking.SpaceList(parkingHouse);
            switch (random.Next(3))
            {
                case 0:
                    Motorcycle motorcycle = new Motorcycle();
                    break;
                case 1:
                    Car car = new Car();
                    break;
                case 2:
                    Bus bus = new Bus();
                    break;
            }

            Console.ReadKey();
        }
    }
}
