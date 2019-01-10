using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Ksiegowa2019.FileSearching
{
    class Faktura
    {
        public string numer { get; set; }
        public string wartosc { get; set; }
        public string date { get; set; }
    }
    class DataGrabing
    {
        static public string path = @"C:\Księgowa2019\Text\";

        public Faktura TakeData(string path= @"C:\Księgowa2019\Text\faktura2.txt")
        {            
            StreamReader streamReader = new StreamReader(path, new UTF8Encoding());           
            string text = streamReader.ReadToEnd();
            string nrFaktury= getBetween(text, "FAKTURA NR", "\r\n\r\n");            
            string razemPLNgrass= getBetween(text, "Razem", "zł");     
            string terminPlatnosci= getBetween(text, "Termin płatności:", "\r");     

            //String text = streamReader.ReadToEnd();
            //Console.WriteLine(text);
            Console.WriteLine(nrFaktury);
            Console.WriteLine(razemPLNgrass);
            Console.WriteLine(terminPlatnosci);
            Faktura faktura = new Faktura();
            faktura.numer = nrFaktury;
            faktura.wartosc = razemPLNgrass;
            faktura.date = terminPlatnosci;

            //using regex

            string regText = Regex.Match(text.ToLower(), @"([,0-9\-]+) zł").Value;
            Console.WriteLine(regText);
            return faktura; 

            //
        }

        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                string subString = strSource.Substring(Start);
                if (subString.Contains(strEnd))
                {
                    End = subString.IndexOf(strEnd, strEnd.Length);
                    string sub2String = subString.Substring(0,End);
                    return sub2String;
                }
                else
                {
                    return "";
                }
            }            
            else
            {
                return "";
            }
            
        }

    }
}
