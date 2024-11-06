namespace Parkeringshus;

internal class Motorcycle : Vehicle
{
    public string Brand { get; set; }

    public Motorcycle()
    {
        Console.WriteLine("En ny motorcykel åker in i parkeringshuset");
        Console.Write("Vad är det för färg: ");
        Color = Console.ReadLine();
        Console.Write("Vad är det för märke: ");
        Brand = Console.ReadLine();

        Parking.AvailableSpace -= 0.5;
    }

    internal override void Info(int index)
    {
        base.Info(index);
        Console.WriteLine($"\tMC\t{Brand}");
    }
}
