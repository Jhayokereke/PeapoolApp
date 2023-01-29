using System;
using System.Collections.Generic;
using System.Text;

namespace PeapoolApp.BL
{
    public class UseApp
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Enter your details to login....");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Password: ");
            var password = Utilities.CollectSecretData();
            if (Database.Users.Exists(x=>x.UserEmail == email))
            {
                var currentUser = Database.Users.Find(x => x.UserEmail == email);
                if (currentUser.Password == password)
                {
                    CurrentUser = currentUser;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Welcome {CurrentUser.FirstName}..... \n\nWhat a great day it is today. {'\u263A'}");
                    LoggedIn();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Email or password incorrect!!!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to return to the main menu?   Enter 'y' for yes.");
                var choice = Console.ReadLine();
                if (choice == "y")
                {
                    Console.Clear();
                    Program.Next();
                }
                else
                {
                    Console.Clear();
                    Login();
                }
            }
        }

        public static User CurrentUser;

        public static void LoggedIn()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You are logged in..." +
                "\n***To view and update your details enter '1'." +
                "\n***To view all user data enter '2'. (Admin Only)" +
                "\n***To logout enter 'l'." +
                "\n***To exit the App enter 'q'.");
            //write a switch case statement to exit or do the following
            //change password and other data
            var choice = (Console.ReadLine()).ToLower();
            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine(CurrentUser);
                    Console.WriteLine();
                    Console.WriteLine("Enter 'u' to update your details....");
                    if (Console.ReadLine() == "u")
                    {
                        UpdateDetails();
                    }
                    else LoggedIn();
                    break;
                case "2":
                    User.PrintData();
                    break;
                case "l":
                    Console.Clear();
                    Program.Next();
                    break;
                case "q":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Goodbye!!!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I don't understand your entry!");
                    Console.ReadLine();
                    Console.Clear();
                    LoggedIn();
                    break;
            }
        }

        public static void UpdateDetails()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***To update your password enter '1'." +
                "\n***To update your phone number enter '2'." +
                "\n***To return to previous menu enter 'r'.");
            Console.WriteLine();
            var input = (Console.ReadLine());
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter a new password and press the enter key to save.");
                    UpdatePassword();
                    break;
                case "2":
                    Console.WriteLine("Enter a phonenumber and press the enter key to save.");
                    UpdatePhoneNumber();
                    break;
                case "r":
                    LoggedIn();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I don't understand your entry!");
                    UpdateDetails();
                    break;
            }
        }

        public static void UpdatePassword()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            while (password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must be at least 6 characters!!!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Password: ");
                password = Console.ReadLine();
            }
            //set a password encryption process and return encrypted password as user password
            CurrentUser.Password = password;
            UpdateDetails();
        }

        public static void UpdatePhoneNumber()
        {
            Console.WriteLine();
            Console.Write("Phonenumber: ");
            var phoneNumber = Console.ReadLine();
            while (Validation.ValidatePhoneNumber(phoneNumber) != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid phoneNumber");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Phonenumber: ");
                phoneNumber = Console.ReadLine();
            }
            CurrentUser.PhoneNumber = new List<string>
            {
                phoneNumber
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Add another phonenumber or tap the enter key to continue...");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.Write("Phonenumber: ");
            phoneNumber = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                while (Validation.ValidatePhoneNumber(phoneNumber) != true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid phoneNumber!!!");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.Write("Phonenumber: ");
                    phoneNumber = Console.ReadLine();
                }
               CurrentUser.PhoneNumber.Add(phoneNumber);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Add another phonenumber or tap the enter key to continue...");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Phonenumber: ");
                phoneNumber = Console.ReadLine();
            }
            int currentLineCursor = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor - 1);
            UpdateDetails();
        }
    }
}
