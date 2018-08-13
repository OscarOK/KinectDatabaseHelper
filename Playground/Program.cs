using System;
using System.IO;
using KinectDatabaseHelper;

namespace Playground
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DatabaseHelper kdh = new DatabaseHelper("DEMO", "12345");
            kdh.CreateTable();

//            kdh.ademo();
//            kdh.GetCsv("C:\\Users\\Oscar Eduardo\\Desktop");

            Console.WriteLine("FINISH");
        }
    }
}