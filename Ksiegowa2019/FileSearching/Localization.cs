using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UsingOCR;

namespace Ksiegowa2019.FileSearching
{
    class Localization
    { 
        public string path { get; set; }

        public Localization()
        {
            //path = Directory.GetCurrentDirectory();
            path = @"C:\Księgowa2019";
        }

        public void ShowPath()
        {
            Console.WriteLine(path);
        }
    }

    class FilesToOCR:Localization
    {
        static public string nazwaFolderuNaSkany = @"\Skany";
        static public string pathToSkany { get; set; }

        public DirectoryInfo directoryInfo { get; set; }
        public FileInfo[] files { get; set; }

        public FilesToOCR()
        {
            pathToSkany = path + nazwaFolderuNaSkany;
        }

        public string makeOCR()
        {
            if (files.Length==0)
            {
                
            }
            string[] pathsToFiles = Directory.GetFiles(path); 
            Console.WriteLine("Zrobie pierwsze OCR");
            string testDocument = pathToSkany+ @"\CCF20160324_00000.jpg";
            //var Results = Ocr.ReadMultiThreaded()
            //var Results2 = Ocr.Read(,);
            //Console.WriteLine(Results.Text);
            

            return "";
        }
        public void pomoc()
        {
            var tom = Directory.Exists(path) ;
            Console.WriteLine(path);
            Console.WriteLine(tom);
        }
        public void pomoc2()
        {
            
            string[] paths = { pathToSkany+ @"\CCF20190107_00000.jpg" };
             
            FileToOCR fileToOCR = new FileToOCR();
            fileToOCR.DoOCR(paths);
        }

    }
}
