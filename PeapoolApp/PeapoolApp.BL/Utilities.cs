using System;
using System.Collections.Generic;
using System.Text;

namespace PeapoolApp.BL
{
    public static class Utilities
    {
        public static string CollectSecretData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    stringBuilder = new StringBuilder();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && stringBuilder.Length > 0)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    continue;
                }
                if (key.KeyChar < 32 || key.KeyChar > 126)
                {
                    continue;
                }
                if (key.Key != ConsoleKey.Backspace)
                {
                    stringBuilder.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            return stringBuilder.ToString();
        }

        public static string CollectNumbers()
        {
            StringBuilder stringBuilder = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && stringBuilder.Length > 0)
                {
                    RemoveLastChar();
                }
                if (key.KeyChar < 32 || key.KeyChar > 126)
                {
                    continue;
                }
                else
                {
                    stringBuilder.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }

            return stringBuilder.ToString();
        }

        private static void RemoveLastChar()
        {
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}
