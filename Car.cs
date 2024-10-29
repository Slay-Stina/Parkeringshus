using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Car : Vehicle
{
    public bool EV {  get; set; }
    public Car()
    {
        ParkSpace = 1;

        Console.WriteLine("En ny bil åker in i parkeringshuset");
        Console.Write("Vad är det för färg: ");
        Color = Console.ReadLine();
        Console.Write("Är det en elbil? 1.JA | 2.NEJ ");
        EV = Check.Bool();
    }
}
