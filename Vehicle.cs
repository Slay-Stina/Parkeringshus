namespace Parkeringshus;

abstract class Vehicle
{
    public static Random Random = new Random();
    public string Color {  get; set; }
    public string RegPlate = GetRandomPlate();
    public DateTime CheckinTime = DateTime.Now;

    private static string GetRandomPlate()
    {
        string regplate = "";
        for (int i = 0; i < 3; i++)
        {
            regplate += (char)Random.Next('A', 'Z' + 1);
        }
        for (int i = 0; i < 3; i++)
        {
            regplate += Random.Next(10).ToString();
        }
        return regplate;
    }

    internal virtual void Info(int index)
    {
        string busSpaceNr = (this is Bus) ? $"-{index + 1}" : "";
        Console.Write($"P {index}{busSpaceNr}");
        Console.Write($"\t{CheckinTime.ToShortTimeString()}\t{RegPlate}\t{Color}");
    }
}
