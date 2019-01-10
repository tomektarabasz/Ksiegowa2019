using System;
using Ksiegowa2019.FileSearching;
using UsingOCR;

namespace Ksiegowa2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataGrabing dataGrabing = new DataGrabing();
            dataGrabing.TakeData();
            
            Console.ReadKey();
        }
    }
}
