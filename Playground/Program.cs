using System;
using KinectDatabaseHelper;

namespace Playground
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DatabaseHelper kdh = new DatabaseHelper("DEMO", "12345");
            kdh.CreateTable();
            Console.WriteLine("FINISH");
        }
    }
}