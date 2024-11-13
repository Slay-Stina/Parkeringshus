namespace Parkeringshus;

internal class Parking
{
    public static double AvailableSpace = 15;
    public static List<object> Space { get; set; }

    public Parking()
    {
        Space = new List<object>();
        for (int i = 1; i <= 15; i++)
        {
            Space.Add(null);
        }
    }

    public class MCSpace
    {
        public Dictionary<string, Motorcycle> MCList = new Dictionary<string, Motorcycle>();
    }

    public static void SpaceList()
    {
        Console.WriteLine("Plats\tIncheck\tReg.Nr\tFärg\tTyp\tUnik egenskap");
        Console.WriteLine("================================================");

        int index = 1;
        foreach (var parking in Space)
        {
            if (parking is null)
            {
                Console.WriteLine($"P {index}");
            }

            switch (parking)
            {
                case MCSpace mcSpace:
                    foreach (var mc in mcSpace.MCList.Values)
                    {
                        mc.Info(index);
                    }
                    break;
                case Car car:
                    car.Info(index);
                    break;
                case Bus bus:
                    if (bus.RegPlate.Length == 6)
                    {
                        bus.Info(index);
                    }
                    break;
            }
            index++;
        }
    }

    internal static void AddCar(Car car)
    {
        foreach (var parking in Space)
        {
            if (parking is null)
            {
                Space[Space.IndexOf(parking)] = car;
                return;
            }
        }
    }

    private static void AddBus(Bus bus)
    {
        for (int i = 0; i < Space.Count - 1; i++)
        {
            if (Space[i] is null && Space[i + 1] is null)
            {
                Space[i] = bus;
                Space[i + 1] = new Bus(bus);
                return;
            }
        }
        NoSpace(2);
    }

    private static void NoSpace(int randomVehicle)
    {
        string vehicle = randomVehicle == 1 ? "bil" : "buss";
        Console.WriteLine($"En {vehicle} försökte parkera, men det fanns inte plats, så den åkte vidare");
        Thread.Sleep(2000);
    }

    private static void AddMotorcycle(Motorcycle motorcycle)
    {
        foreach (var parking in Space)
        {
            if (parking is MCSpace mcSpace && mcSpace.MCList.Count < 2)
            {
                mcSpace.MCList.Add(motorcycle.RegPlate, motorcycle);
                return;
            }
            if (parking is null)
            {
                MCSpace MCSpace = new MCSpace();
                MCSpace.MCList.Add(motorcycle.RegPlate, motorcycle);
                Space[Space.IndexOf(parking)] = MCSpace;
                return;
            }
        }
    }

    internal static void NewVehicle(int randomVehicle)
    {
        if (AvailableSpace == 0)
        {
            Console.WriteLine("Parkeringhuset är fullt! Någon måste checka ut.");
            Thread.Sleep(2000);
            return;
        }

        switch (randomVehicle)
        {
            case 0:
                AddMotorcycle(new Motorcycle());
                break;
            case 1:
                if (AvailableSpace >= 1)
                    AddCar(new Car());
                else
                    NoSpace(randomVehicle);
                break;
            case 2:
                if (AvailableSpace >= 2)
                    AddBus(new Bus());
                else
                    NoSpace(randomVehicle);
                break;
        }
    }
}