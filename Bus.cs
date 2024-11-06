namespace Parkeringshus;

internal class Bus : Vehicle
{
    public int Passengers { get; set; }
    public Bus()
    {
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

    internal override void Info(int index)
    {
        base.Info(index);
        Console.WriteLine($"\tBuss\t{Passengers} platser");
    }
}
