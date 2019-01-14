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
        public DateTime date { get; set; }
        public string nazwaKontrahenta { get; set; }
        public string nipKontrahenta { get; set; }
        public string kupnoSprzedaz { get; set; }
    }
    class DataGrabing
    {
        static public string path = @"C:\Księgowa2019\Text\";



        public List<Faktura> TakeData(string path= @"C:\Księgowa2019\Text\")
        {
            DirectoryInfo textDirectory = new DirectoryInfo(path);
            var fileInfoInTextDirectory = textDirectory.GetFiles();

            List<Faktura> listaFaktur = new List<Faktura>();

            foreach (var pathOfFile in fileInfoInTextDirectory)
            { 
                StreamReader streamReader = new StreamReader(pathOfFile.ToString(), new UTF8Encoding());           
                string text = streamReader.ReadToEnd();

                text = replacingOfLongDash(text);

                //regex patterns
                Regex nrFakturyPattern = new Regex(@"faktura nr ([0-9/\\-]+)");
                Regex razemPLNgrassPattern = new Regex(@"razem ([0-9,-]+) zł");
                Regex dataWystawieniaPattern = new Regex(@"Data wystawienia ([0-9\-.,-]+)");
                Regex nipKontrahentaPattern = new Regex(@"NIP ([?0-9\-]+)");
                Regex nazwaKontrahentaPattern = new Regex("Odbiorca: ([A-Za-z?0-9\"\\-()]+) (\\w+\\s\\w+)");
                Regex nazazwaTaty = new Regex("Krzysztof Tarabasz");

                string nrFaktury = Regex.Match(text,nrFakturyPattern.ToString(), RegexOptions.IgnoreCase).Value;

                string razemPLNgrass = Regex.Match(text, razemPLNgrassPattern.ToString(), RegexOptions.IgnoreCase).Value;
                razemPLNgrass = Regex.Match(razemPLNgrass, "([0-9,]+)").Value;

                string terminPlatnosci = Regex.Match(text, dataWystawieniaPattern.ToString(), RegexOptions.IgnoreCase).Value; ;
                terminPlatnosci = Regex.Match(terminPlatnosci, "([0-9,./\\-]+)").Value;            
                DateTime terminPlatnosciDateTime2 = DateTime.Parse(terminPlatnosci,new CultureInfo("de-DE"));

                string nipKontrahenta = Regex.Match(text, nipKontrahentaPattern.ToString(),RegexOptions.IgnoreCase).Value;
            
                string nazwaKontrahenta = Regex.Match(text, nazwaKontrahentaPattern.ToString(),RegexOptions.IgnoreCase).Value;

                string fakturaSprzedazCzyZakup = checkIfBuyOrSell(text);

                var jj = Regex.Match(text, nipKontrahentaPattern.ToString(), RegexOptions.IgnoreCase);

                CultureInfo cultureInfo = new CultureInfo("pl-PL");
                Console.WriteLine(cultureInfo.EnglishName);
                //
                //string nrFaktury= getBetween(text, "FAKTURA NR", "\r\n\r\n");            
                //string razemPLNgrass= getBetween(text, "Razem", "zł");     
                //string terminPlatnosci= getBetween(text, "Termin płatności:", "\r");
                        
                Faktura faktura = new Faktura();
                faktura.numer = nrFaktury;
                faktura.wartosc = razemPLNgrass;
                faktura.date = terminPlatnosciDateTime2;
                faktura.nipKontrahenta = findContractorNip(text);
                faktura.nazwaKontrahenta = nazwaKontrahenta;
                faktura.kupnoSprzedaz = checkIfBuyOrSell(text);

                Console.WriteLine("Zrobiona faktura nr {}",nrFaktury);
                listaFaktur.Add(faktura);
            }

            return listaFaktur; 

            //
        }
        public string checkIfBuyOrSell(string text)
        {
            string nipTaty = "7991037389";
            string sell = "sprzedaz";
            string buy = "kupno";
                        
            Regex nipPattern = new Regex("NIP([:A-Za-z?0-9\"\\-()\\ \\—]+)");

            var pierwszyNip = Regex.Match(text, nipPattern.ToString(), RegexOptions.IgnoreCase).Groups[1];            
            string pierwszyNip2=Regex.Replace(pierwszyNip.ToString(), "([\\-\\—])","");

            //var nipy2 = Regex.Matches(text, nipPattern.ToString(), RegexOptions.IgnoreCase);

            if (Regex.IsMatch(pierwszyNip2, nipTaty))
            {
                return sell;
            }
            else
            {
                return buy;
            }
        }
        public string findContractorNip(string text)
        {
            string nipTaty = "7991037389";
            string nipContractor ="";
            Regex nipPatternRequirement = new Regex("([\\d{10}])");
            Regex nipPattern = new Regex("NIP([:A-Za-z?0-9\"\\-()\\ \\—]+)");
            MatchCollection nipy = Regex.Matches(text, nipPattern.ToString(), RegexOptions.IgnoreCase);

            foreach (Match nip in nipy)
            {
                string rawNip = Regex.Replace(nip.Value.ToString(), "([A-Za-z\\-\\—\\ ])", "");
                if (!(rawNip == nipTaty) && (Regex.IsMatch(rawNip, nipPatternRequirement.ToString())))
                {
                    nipContractor = nip.Value.ToString();
                    break;
                }
                else
                {
                    nipContractor = "nie znalazłem nip-u kontrahenta";
                }
            }
            return nipContractor;
        }
        public string replacingOfLongDash(string text)
        {

            string textWithOutLongDash = text.Replace("—", "-");
            return textWithOutLongDash;
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
