using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string nazwaKontrahenta { get; set; }
        public string nipKontrahenta { get; set; }
    }
    class DataGrabing
    {
        static public string path = @"C:\Księgowa2019\Text\";

        public Faktura TakeData(string path= @"C:\Księgowa2019\Text\faktura2.txt")
        {            
            StreamReader streamReader = new StreamReader(path, new UTF8Encoding());           
            string text = streamReader.ReadToEnd();
            //regex patterns
            Regex nrFakturyPattern = new Regex(@"faktura nr ([0-9/\\-]+)");
            Regex razemPLNgrassPattern = new Regex(@"razem ([0-9,-]+) zł");
            Regex dataWystawieniaPattern = new Regex(@"Data wystawienia ([0-9\-.,-]+)");

            string nrFaktury = Regex.Match(text,nrFakturyPattern.ToString(), RegexOptions.IgnoreCase).Value;
            string razemPLNgrass = Regex.Match(text, razemPLNgrassPattern.ToString(), RegexOptions.IgnoreCase).Value;
            razemPLNgrass = Regex.Match(razemPLNgrass, "([0-9,]+)").Value;
            string terminPlatnosci = Regex.Match(text, dataWystawieniaPattern.ToString(), RegexOptions.IgnoreCase).Value; ;
            terminPlatnosci = Regex.Match(terminPlatnosci, "([0-9,./\\-]+)").Value;
            DateTime terminPlatnosciDateTime = DateTime.Parse(terminPlatnosci,new CultureInfo("eu-US"));
            DateTime terminPlatnosciDateTime2 = DateTime.Parse(terminPlatnosci,new CultureInfo("de-DE"));
            DateTime terminPlatnosciDateTime3 = DateTime.Parse(terminPlatnosci,new CultureInfo("fr-FR"));
            DateTime terminPlatnosciDateTime4 = DateTime.Parse(terminPlatnosci,new CultureInfo("pl-PL"));
            CultureInfo cultureInfo = new CultureInfo("pl-PL");
            Console.WriteLine(cultureInfo.EnglishName);
            //
            //string nrFaktury= getBetween(text, "FAKTURA NR", "\r\n\r\n");            
            //string razemPLNgrass= getBetween(text, "Razem", "zł");     
            //string terminPlatnosci= getBetween(text, "Termin płatności:", "\r");

            Console.WriteLine(nrFaktury);
            Console.WriteLine(razemPLNgrass);
            Console.WriteLine(terminPlatnosci);
            Faktura faktura = new Faktura();
            faktura.numer = nrFaktury;
            faktura.wartosc = razemPLNgrass;
            faktura.date = terminPlatnosci;            

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
