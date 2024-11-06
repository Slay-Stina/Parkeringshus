namespace Parkeringshus;

internal class Car : Vehicle
{
    public bool EV { get; set; }
    public Car()
    {
        Console.WriteLine("En ny bil åker in i parkeringshuset");
        Console.Write("Vad är det för färg: ");
        Color = Console.ReadLine();
        Console.Write("Är det en elbil? 1.JA | 2.NEJ ");
        EV = Check.Bool();

        Parking.AvailableSpace -= 1;
    }

    internal override void Info(int index)
    {
        base.Info(index);
        Console.WriteLine($"\tBil\t{(EV ? "el" : "vanlig ")}bil");
    }
}
