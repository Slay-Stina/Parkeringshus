using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus;

internal class Vehicle
{
    public static Random Random = new Random();
    public string Color;
    public string RegPlate = GetRandomPlate();

    public double ParkSpace { get; set; }

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
}
