using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Check
{
    internal static bool Bool()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                return (choice == 1) ? true : false;
            }
            
            Console.WriteLine("Fel input, ange igen: ");
        }
    }

    internal static bool ForBusSpace()
    {
        for (int i = 0; i < Parking.Space.Count-1; i++)
        {
            if (Parking.Space.ElementAt(i).Value is null && Parking.Space.ElementAt(i + 1).Value is null)
            {
                return true;
            }
        }
        return false;
    }

    internal static int Int()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int output))
            {
                return output;
            }

            Console.WriteLine("Fel input, ange igen: ");
        }
    }

    internal static void Out()
    {
        Console.WriteLine("Skriv registreringsnumret för fordonet du vill ckecka ut:");
        string checkOutReg = Console.ReadLine().ToUpper();
        if (checkOutReg != null && checkOutReg != "" && checkOutReg.Length == 6)
        {
            foreach (var parking in Parking.Space)
            {
                if (parking.Value is not null)
                {
                    if (parking.Value is Vehicle)
                    {
                        Vehicle vehicle = (Vehicle)parking.Value;
                        if (vehicle.RegPlate.Contains(checkOutReg))
                        {
                            Parking.Space[parking.Key] = null;
                        }
                    }
                    if (parking.Value is Parking.MCSpace)
                    {
                        Parking.MCSpace MCSpace = (Parking.MCSpace)parking.Value;
                        foreach (var MC in MCSpace.MCList)
                        {
                            if (MC.Value.RegPlate.Contains(checkOutReg))
                            {
                                MCSpace.MCList.Remove(MC.Key);
                            }
                        }
                        if (MCSpace.MCList.Count == 0)
                        {
                            Parking.Space[parking.Key] = null;
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Fel input");
            Thread.Sleep(2000);
        }

    }
}
