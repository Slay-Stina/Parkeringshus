namespace Parkeringshus;

internal class Parking
{
    public static double AvailableSpace = 15;
    public static Dictionary<string, Object> Space { get; set; }

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
        Console.WriteLine("Plats\tIncheck\tReg.Nr\tFärg\tTyp\tUnik egenskap");
        Console.WriteLine("================================================");

        int index = 1;
        foreach (var parking in Space)
        {
            if (parking.Value is null)
            {
                Console.Write($"P {parking.Key}");
                Console.WriteLine();
            }

            if (parking.Value is MCSpace)
            {
                foreach (var MC in ((MCSpace)parking.Value).MCList)
                {
                    Motorcycle motorcycle = MC.Value;
                    motorcycle.Info(index);
                }
            }

            if (parking.Value is Car)
            {
                Car car = (Car)parking.Value;
                car.Info(index);
            }

            if (parking.Value is Bus && ((Bus)parking.Value).RegPlate.Length == 6)
            {
                Bus bus = (Bus)parking.Value;
                bus.Info(index);
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
        for (int i = 0; i < Space.Count - 1; i++)
        {
            if (Space.ElementAt(i).Value is null && Space.ElementAt(i + 1).Value is null)
            {
                Space[Space.ElementAt(i).Key] = bus;
                Space[Space.ElementAt(i + 1).Key] = new Bus(bus);
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
            if (parking.Value is MCSpace mcSpace && mcSpace.MCList.Count < 2)
            {
                mcSpace.MCList.Add(motorcycle.RegPlate, motorcycle);
                return;
            }
            if (parking.Value is null)
            {
                AddMCSpace(parking, motorcycle);
                return;
            }
        }
    }

    private static void AddMCSpace(KeyValuePair<string, object> parking, Motorcycle motorcycle)
    {
        MCSpace MCSpace = new MCSpace();
        MCSpace.MCList.Add(motorcycle.RegPlate, motorcycle);
        Space[parking.Key] = MCSpace;
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