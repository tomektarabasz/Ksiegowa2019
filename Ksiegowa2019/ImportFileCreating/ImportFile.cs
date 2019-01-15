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
