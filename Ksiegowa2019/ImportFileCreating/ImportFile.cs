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
        public string inputFileText = @"[Dokument 1]
TYP=Dokument księgowy
KONTRAHENT=Odbiorca
NUMER DOKUMENTU=0022/2017
DATA=10/05/2017
OPIS=Sprzedaż towarów
REJESTR=1
KOLUMNA=7
NETTO-23=100
VAT-23=23
KWOTA=123
KOREKTA=nie
DATA OTRZYMANIA=10/05/2017
KONTRAHENT-NAZWA PELNA = Odbiorca
KONTRAHENT-ULICA=Kwiatowa 8/10
KONTRAHENT-MIEJSCOWOSC=Stokrotka
KONTRAHENT-KOD POCZTOWY = 20 - 345
KONTRAHENT-NIP=849-398-21-32";
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
