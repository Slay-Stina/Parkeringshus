using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Bus : Vehicle
{
    public int Passengers { get; set; }
    public Bus()
    {
        ParkSpace = 2;

        Console.WriteLine("En ny buss åker in i parkeringshuset");
        Console.Write("Vad är det för färg: ");
        Color = Console.ReadLine();
        Console.Write("Hur många platser har den: ");
        Passengers = Check.Int();

        Parking.AvailableSpace -= 2;
    }

    public Bus(Bus bus)
    {
        RegPlate = bus.RegPlate + "x";
    }
}
