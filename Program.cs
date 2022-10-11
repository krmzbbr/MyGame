using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;

namespace WeekSixFallTuesday
{
    internal class Program
    {
        //Make console window full size on start
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        
        static void Main(string[] args)
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3

            //Console.WriteLine("What is your age?");

            //try
            //{
            //    int result = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"You are {result} years old.");

            //    Console.WriteLine("What is your age again?");
            //    result = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"You are {result} years old.");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"That was not a number. {ex.Message}");
            //    //throw;
            //}

            //do you know the difference between an absolute and relative path?
            string path = @"c:\temp\MyTest.txt"; //absolute paths only work with the exact same path!
            string relativePath = "MyTest.txt"; //This is an example of a relative path - put in same folder as .exe


            //if (File.Exists(path))
            //{
            //    Console.WriteLine("File exists");
            //}
            //else
            //{
            //    Console.WriteLine("File NOT FOUND");
            //}

            //File.Exists() will return a boolean (true or false) value
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello");
            //        sw.WriteLine("And");
            //        sw.WriteLine("Welcome");
            //    }
            //}

            //string bedroomContentPath = @"c:\temp\bedroom.txt";
            //string bedroomContent = Utility.ReadFromFile(bedroomContentPath);
            //Console.WriteLine(bedroomContent);

            //string livingroomContentPath = @"c:\temp\livingroom.txt";
            //string livingroomContent = Utility.ReadFromFile(livingroomContentPath);
            //Console.WriteLine(livingroomContent);

            Game game = Utility.LoadGameFromHardDrive();

            game.NumberOfTimeGamePlayed = game.NumberOfTimeGamePlayed + 1;

            Utility.SaveGameToHardDrive(game);

            Console.WriteLine($"Game:{game.Name} Score: {game.Score} Number of times it was played: {game.NumberOfTimeGamePlayed}");

            Console.ReadLine();

        }
    }
}
