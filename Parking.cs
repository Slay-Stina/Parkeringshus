using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Parking
{
    public static double AvailableSpace = 15;
    public static Dictionary<string,Object> Space { get; set; }

    public Parking()
    {
        Space = new Dictionary<string, Object>();
        for (int i = 1; i <= 15; i++)
        {
            Space.Add($"{i}", null);
        }
        
    }
    public static void SpaceList()
    {
        int index = 1;
        foreach (var parking in Space)
        {
            if(parking.Value is null)
            {
                Console.Write($"Plats {parking.Key}");
                Console.WriteLine();
            }

            if (parking.Value is MCSpace)
            {
                foreach (var MC in ((MCSpace)parking.Value).MCList)
                {
                    Console.Write($"Plats {index}");
                    Motorcycle motorcycle = MC.Value;
                    Console.WriteLine($"\tMC\t{motorcycle.RegPlate}\t{motorcycle.Color}\t{motorcycle.Brand}");
                }
            }

            if (parking.Value is Car)
            {
                Console.Write($"Plats {index}");
                Car car = (Car)parking.Value;
                Console.WriteLine($"\tBil\t{car.RegPlate}\t{car.Color}\t{(car.EV ? "el" : "vanlig ")}bil");
            }

            if (parking.Value is Bus)
            {
                Console.Write($"Plats {index}");
                Bus bus = (Bus)parking.Value;
                Console.WriteLine($"\tBuss\t{bus.RegPlate}\t{bus.Color}\t{bus.Passengers} platser");
            }
            index++;
        }
    }

    internal static void AddVehicle(Vehicle vehicle)
    {
        if (vehicle is Motorcycle)
        {
            AddMotorcycle(vehicle);
            return;
        }
        foreach (var parking in Space)
        {
            if (parking.Value is null && vehicle is Car)
            {
                Space[parking.Key] = vehicle;
                return;
            }            
        }
        
    }

    private static void AddBus(KeyValuePair<string, object> parking, Vehicle vehicle)
    {
        Space.Remove(parking.Key);
        Bus bus = (Bus)vehicle;

    }

    private static void AddMotorcycle(Vehicle vehicle)
    {
        Motorcycle motorcycle = (Motorcycle)vehicle;

        foreach (var parking in Space)
        {
            if (!Space.Values.Contains(parking.Value is MCSpace) && parking.Value is null)
            {
                MCSpace MCSpace = new MCSpace();
                Space[parking.Key] = MCSpace;
                MCSpace.MCList.Add(vehicle.RegPlate, (Motorcycle)vehicle);
                return;
            }
            if (parking.Value is MCSpace && ((MCSpace)parking.Value).MCList.Count < 2)
            {
                MCSpace MCSpace = (MCSpace)parking.Value;
                MCSpace.MCList.Add(vehicle.RegPlate, (Motorcycle)vehicle);
                return;
            }
            else if (parking.Value is null)
            {
                MCSpace MCSpace = new MCSpace();
                Space[parking.Key] = MCSpace;
                MCSpace.MCList.Add(vehicle.RegPlate, (Motorcycle)vehicle);
                return;
            }
        }
    }

    internal static void NewVehicle(int randomVehicle)
    {
        if (AvailableSpace == 0.5)
        {
            Console.WriteLine("Det finns bara plats för en motorcykel kvar i parkeringshuset.");
            AddVehicle(new Motorcycle());
        }
        else if ( AvailableSpace < 2)
        {
            switch (randomVehicle)
            {
                case 0:
                    AddVehicle(new Motorcycle());
                    break;
                case 1:
                    AddVehicle(new Car());
                    break;
            }
        }
        else if (AvailableSpace > 2)
        {
            switch (randomVehicle)
            {
                case 0:
                    AddVehicle(new Motorcycle());
                    break;
                case 1:
                    AddVehicle(new Car());
                    break;
                case 2:
                    Console.WriteLine("En buss");
                    //AddVehicle(new Bus());
                    break;
            }
        }
        else
        {
            Console.WriteLine("Parkeringhuset är fullt! Någon måste checka ut.");
        }
    }

    internal static void CheckOut()
    {
        throw new NotImplementedException();
    }

    private class MCSpace
    {
        public Dictionary<string, Motorcycle> MCList { get; set; }
        public MCSpace()
        {
            MCList = new Dictionary<string, Motorcycle>();
        }
    }
}