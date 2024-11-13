namespace Parkeringshus;

abstract class Check
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
                if (parking is Vehicle vehicle && vehicle.RegPlate.Contains(checkOutReg))
                {
                    CheckoutString(vehicle);
                    if (vehicle is Bus)
                    {
                        Parking.Space[Parking.Space.IndexOf(parking) + 1] = null;
                    }
                    Parking.Space[Parking.Space.IndexOf(parking)] = null;
                    return;
                }
                if (parking is Parking.MCSpace MCSpace)
                {
                    foreach (var MC in MCSpace.MCList)
                    {
                        if (MC.Value.RegPlate.Contains(checkOutReg))
                        {
                            CheckoutString(MC.Value);
                            MCSpace.MCList.Remove(MC.Key);
                        }
                    }
                    if (MCSpace.MCList.Count == 0)
                    {
                        Parking.Space[Parking.Space.IndexOf(parking)] = null;
                    }
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("Fel input");
            Thread.Sleep(2000);
        }

    }

    private static void CheckoutString(Vehicle vehicle)
    {
        TimeSpan inOutDiff = DateTime.Now - vehicle.CheckinTime;
        if (vehicle.RegPlate.Length == 6)
        {
            Console.WriteLine($"{vehicle.RegPlate} parkerade {inOutDiff.Minutes} minuter och det kostade {inOutDiff.Minutes * 1.5}kr"); 
        }
        if(vehicle is Car)
        {
            Parking.AvailableSpace += 1;
        }
        if (vehicle is Bus)
        {
            Parking.AvailableSpace += 2;
        }
        if (vehicle is Motorcycle)
        {
            Parking.AvailableSpace += 0.5;
        }
        Thread.Sleep(2000);
    }
}
