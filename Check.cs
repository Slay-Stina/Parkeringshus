﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkeringshus
{
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
    }
}
