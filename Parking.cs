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
    public class MCSpace
    {
        public Dictionary<string, Motorcycle> MCList { get; set; }
        public MCSpace()
        {
            MCList = new Dictionary<string, Motorcycle>();
        }
    }
    public static void SpaceList()
    {
        string header = "Plats\tTyp\tReg.Nr\tFärg\tUnikt";
        Console.WriteLine(header);
        Console.WriteLine("=====================================");

        int index = 1;
        foreach (var parking in Space)
        {
            if(parking.Value is null)
            {
                Console.Write($"P {parking.Key}");
                Console.WriteLine();
            }

            if (parking.Value is MCSpace)
            {
                foreach (var MC in ((MCSpace)parking.Value).MCList)
                {
                    Console.Write($"P {index}");
                    Motorcycle motorcycle = MC.Value;
                    Console.WriteLine($"\tMC\t{motorcycle.RegPlate}\t{motorcycle.Color}\t{motorcycle.Brand}");
                }
            }

            if (parking.Value is Car)
            {
                Console.Write($"P {index}");
                Car car = (Car)parking.Value;
                Console.WriteLine($"\tBil\t{car.RegPlate}\t{car.Color}\t{(car.EV ? "el" : "vanlig ")}bil");
            }

            if (parking.Value is Bus && ((Bus)parking.Value).RegPlate.Length == 6)
            {
                Bus bus = (Bus)parking.Value;
                Console.Write($"P {index}-{index+1}");
                Console.WriteLine($"\tBuss\t{bus.RegPlate}\t{bus.Color}\t{bus.Passengers} platser");
            }
            index++;
        }
    }

    internal static void AddCar(Car car)
    {
        foreach (var parking in Space)
        {
            if (parking.Value is null)
            {
                Space[parking.Key] = car;
                return;
            }            
        }
        
    }

    private static void AddBus(Bus bus)
    {
        for (int i = 0; i < Space.Count; i++)
        {
            if (Space.ElementAt(i).Value is null && Space.ElementAt(i+1).Value is null)
            {
                Space[Space.ElementAt(i).Key] = bus;
                Space[Space.ElementAt(i+1).Key] = new Bus(bus);
                return;
            }
        }
    }

    private static void AddMotorcycle(Motorcycle motorcycle)
    {
        foreach (var parking in Space)
        {
            if (!Space.Values.Contains(parking.Value is MCSpace) && parking.Value is null)
            {
                MCSpace MCSpace = new MCSpace();
                Space[parking.Key] = MCSpace;
                MCSpace.MCList.Add(motorcycle.RegPlate, (Motorcycle)motorcycle);
                return;
            }
            if (parking.Value is MCSpace && ((MCSpace)parking.Value).MCList.Count < 2)
            {
                MCSpace MCSpace = (MCSpace)parking.Value;
                MCSpace.MCList.Add(motorcycle.RegPlate, (Motorcycle)motorcycle);
                return;
            }
            else if (parking.Value is null)
            {
                MCSpace MCSpace = new MCSpace();
                Space[parking.Key] = MCSpace;
                MCSpace.MCList.Add(motorcycle.RegPlate, (Motorcycle)motorcycle);
                return;
            }
        }
    }

    internal static void NewVehicle(int randomVehicle)
    {
        if (AvailableSpace == 0.5)
        {
            Console.WriteLine("Det finns bara plats för en motorcykel kvar i parkeringshuset.");
            AddMotorcycle(new Motorcycle());
        }
        else if (AvailableSpace >= 2)
        {
            switch (randomVehicle)
            {
                case 0:
                    AddMotorcycle(new Motorcycle());
                    break;
                case 1:
                    AddCar(new Car());
                    break;
                case 2:
                    if (Check.ForBusSpace())
                    {
                        AddBus(new Bus());
                    }
                    else
                    {
                        Console.WriteLine("En buss försöker parkera, men det finns inte 2 lediga platser bredvid varandra, så den åkte vidare");
                        Thread.Sleep(2000);
                    }
                    break;
            }
        }
        else if (AvailableSpace < 2 && AvailableSpace > 0)
        {
            switch (randomVehicle)
            {
                case 0:
                    AddMotorcycle(new Motorcycle());
                    break;
                case 1:
                    AddCar(new Car());
                    break;
                default:
                    Console.WriteLine("En buss försöker parkera, men det finns inte 2 lediga platser bredvid varandra, så den åkte vidare");
                    Thread.Sleep(2000);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Parkeringhuset är fullt! Någon måste checka ut.");
            Thread.Sleep(2000);
        }
    }
}