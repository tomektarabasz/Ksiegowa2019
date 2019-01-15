using Ksiegowa2019.FileSearching;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ksiegowa2019.ImportFileCreating
{
    class ImportFile
    {
        public const string path = @"C:\Księgowa2019\Text\uuuuu.ini";
        public string inputFileText2 = "[Dokument 1]\r\n" +
            "TYP=Dokument księgowy\r\n" +
            "KONTRAHENT=Odbiorca\r\n" +
            "NUMER DOKUMENTU=0022/2017\r\n" +
            "DATA=10/05/2017\r\n" +
            "OPIS=Sprzedaż towarów\r\n" +
            "REJESTR=1\r\n" +
            "KOLUMNA=7\r\n" +
            "NETTO-23=100\r\n" +
            "VAT-23=23\r\n" +
            "KWOTA=123\r\n" +
            "KOREKTA=nie\r\n" +
            "DATA OTRZYMANIA=10/05/2017\r\n" +
            "KONTRAHENT-NAZWA PELNA = Odbiorca\r\n" +
            "KONTRAHENT-ULICA=Kwiatowa 8/10\r\n" +
            "KONTRAHENT-MIEJSCOWOSC=Stokrotka\r\n" +
            "KONTRAHENT-KOD POCZTOWY = 20 - 345\r\n" +
            "KONTRAHENT-NIP=849-398-21-32";

        

        public string createOneDocument(List<Faktura> faktury)
        {
            int i = 0;
            List<string> stringList = new List<string>();
            string createDocument="";
            foreach (Faktura faktura in faktury)
            {
                List<string> parametry = new List<string>();
                parametry.Add(i.ToString());
                parametry.Add("Dokument księgowy");
                parametry.Add(faktura.nazwaKontrahenta);
                parametry.Add(faktura.numer);
                parametry.Add(faktura.date.ToString());
                parametry.Add("Opis");
                parametry.Add("1");//Rejest Vat sprawdz
                parametry.Add(nrKontaPrzyKupSprzedaz(faktura));
                parametry.Add(nettoKwota(faktura));
                parametry.Add(podatekVat(faktura));
                parametry.Add(faktura.wartosc);
                parametry.Add(faktura.korekta);
                parametry.Add("");
                parametry.Add("");
                parametry.Add("");
                parametry.Add("");
                parametry.Add("");
                parametry.Add(faktura.nipKontrahenta);


                string inputFileText = "[Dokument {0}]\r\n" +
                "TYP={1}\r\n" +
                "KONTRAHENT={2}\r\n" +
                "NUMER DOKUMENTU={3}r\n" +
                "DATA={4}\r\n" +
                "OPIS={5}\r\n" +
                "REJESTR={6}\r\n" +
                "KOLUMNA={7}\r\n" +
                "NETTO-23={8}\r\n" +
                "VAT-23=23\r\n" +
                "KWOTA={9}\r\n" +
                "KOREKTA={10}\r\n" +
                "DATA OTRZYMANIA={11}\r\n" +
                "KONTRAHENT-NAZWA PELNA = {12}\r\n" +
                "KONTRAHENT-ULICA={13}\r\n" +
                "KONTRAHENT-MIEJSCOWOSC={14}\r\n" +
                "KONTRAHENT-KOD POCZTOWY = {15}\r\n" +
                "KONTRAHENT-NIP={16}\r\n";
                stringList.Add(String.Format(inputFileText,parametry));
                i++;
            }
            foreach (string str in stringList)
            {
                createDocument = createDocument + str;
            }
            return "";
        }
        public string nrKontaPrzyKupSprzedaz(Faktura faktura)
        {
            if (faktura.kupnoSprzedaz=="sprzedaz")
            {
                return "7";
            }
            else
            {
                return "8";
            }            
        }
        public string nettoKwota(Faktura faktura)
        {
            try
            {
                double wartosc=Convert.ToDouble(faktura.wartosc);
                double wartoscNetto = wartosc / 1.23;
                return wartoscNetto.ToString();
            }
            catch
            {


            }
            return "";
        }
        public string podatekVat(Faktura faktura)
        {
            try
            {
                double wartosc = Convert.ToDouble(faktura.wartosc);
                double wartoscPodatku = wartosc / 1.23 * 0.23;
                return wartoscPodatku.ToString();
            }
            catch
            {
            }

            return "";
        }
        public static void createImportFile(string txt,Faktura faktura)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);            
            StreamWriter streamWriter = new System.IO.StreamWriter(path, false, Encoding.GetEncoding("windows-1250"));
            streamWriter.Write(txt);
            streamWriter.Close();
            

            //StreamWriter tt = File.CreateText(path);                        
            //tt.WriteLine(txt);
            //tt.Close();

        }
        
    }
}
