using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Parking
{
    private int AvailableSpace {  get; set; }
    public List<Vehicle> Space { get; set; }
    public Parking()
    {
        AvailableSpace = 1;
        Space = new List<Vehicle>();
    }
    public static void SpaceList(List<Parking> parkingHouse)
    {
        foreach (Parking parking in parkingHouse)
        {
            Console.Write($"Nr {parkingHouse.IndexOf(parking) + 1}");
            foreach (Vehicle v in parking.Space)
            {
                if (v is Motorcycle)
                {
                    Console.Write($"\tMC\t{v.RegPlate}\t{v.Color}\t{((Motorcycle)v).Brand}");
                }
                if (v is Car)
                {
                    Console.Write($"\tBil\t{v.RegPlate}\t{v.Color}\t{(((Car)v).EV ? "el" : "vanlig ")}bil");
                }
                if (v is Bus)
                {
                    Console.Write($"\tBuss\t{v.RegPlate}\t{v.Color}\t{((Bus)v).Passengers} platser");
                }
            }
            Console.WriteLine();
        }
    }
}