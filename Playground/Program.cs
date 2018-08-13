using System;
using System.Diagnostics;
using System.IO;
using KinectDatabaseHelper;
using Microsoft.Kinect;

namespace Playground
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var kinect = KinectSensor.GetDefault();
            var kdh = new DatabaseHelper("DEMO", "12345");
            kdh.CreateTable();
            kdh.ClearTable();
            
            Console.WriteLine("START");
            
            stopwatch.Start();
            kdh.RunKinect(ref kinect);
            Console.ReadKey();
            kinect.Close();
            stopwatch.Stop();
            
            kdh.GetCsv("C:\\Users\\Oscar Eduardo\\Desktop");
            Console.WriteLine("FINISH");
            
            var time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(string.Format("{0:d2}:{1:d2}:{2:d2}:{3:d3}", time / 3600000, (time / 60000) % 60,
                (time / 1000) % 60, time % 1000));
            Console.WriteLine("{0} logs in approx", (time / 1000) * 15);
        }
    }
}