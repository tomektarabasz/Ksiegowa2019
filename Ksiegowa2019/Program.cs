using System;
using System.Collections.Generic;
using Ksiegowa2019.FileSearching;
using Ksiegowa2019.windowsUserSimulation;



namespace Ksiegowa2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataGrabing dataGrabing = new DataGrabing();
            dataGrabing.TakeData();

            List<Faktura> faktury = new List<Faktura>();
            faktury = dataGrabing.TakeData();
            
            //Console.ReadKey();
        }
    }
}
