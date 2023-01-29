using System;
using System.Collections.Generic;
using System.Threading;

namespace PeapoolApp.BL
{
    public class Program
    {
        public static void Main()
        {
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //string welcomeMessage = "There are over a million different spieces scattered on and below the surface of the earth." +
            //"\nOrganisms of all kinds just enough to fill the earth. Not too much, not too little. " +
            //"\nThere are approximately 6 billion people in the world. Welcome to the world of Peapool.";
            //foreach (char item in welcomeMessage)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(50);
            //    if (item == '.')
            //    {
            //        //Thread.Sleep(1000);
            //    }
            //    else if (item == ',')
            //    {
            //        //Thread.Sleep(700);
            //    }
            //}

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //var loadingText = "Starting Up ";
            //Console.Write(loadingText);
            //var cursorPosition = Console.CursorLeft;

            //for (int i = 0; i < 16; i++)
            //{
            //    Console.Write('.');
            //    //Thread.Sleep(700);
            //    if (i % 5 == 0)
            //    {
            //        Console.SetCursorPosition(cursorPosition, Console.CursorTop);
            //        Console.Write("      ");
            //        Console.SetCursorPosition(cursorPosition, Console.CursorTop);
            //    }
            //}

            ////Thread.Sleep(3000);
            //Console.Clear();
            Next();
        }

        public static void Next()
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Enter the appropriate key to perform an action" +
                "\n\'l\' to login" +
                "\n\'r\' to register" +
                "\n\'q\' to quit");
            var input = (Console.ReadLine()).ToLower();
            switch (input)
            {
                case "r":
                    Registration.RegType();
                    break;
                case "l":
                    UseApp.Login();
                    break;
                case "q":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Goodbye!!!!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid entry!!!");
                    Console.ReadKey();
                    Console.Clear();
                    Next();
                    break;
            }

        }
    }
}