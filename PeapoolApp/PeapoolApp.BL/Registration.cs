using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PeapoolApp.BL
{
    public class Registration
    {
        public static void RegType()
        {
            Console.Clear();
            Console.WriteLine("To register as an admin decipher the following code");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  -.. . -.-. .- --. --- -.");
            Console.Write("Answer: ");
            var ans = Utilities.CollectSecretData();
            Console.WriteLine();
            Console.ResetColor();

            if (ans.ToLower() == "decagon")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct! Even among men there are gods.");
                Thread.Sleep(700);
                Console.Clear();
                Console.ResetColor();
                AdminReg(); 
                //assign admin role and proceed to admin registration
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops! Not all men are born great.");
                Thread.Sleep(700);
                Console.Clear();
                Console.ResetColor();
                MemberReg();
                //assign member role and proceed to member registration
            }
        }

        public static void AdminReg()
        {
            //set role to "0", create a new user based on role
            User newUser = new User(Role.Admin);
            CollectData(newUser);
        }

        public static void MemberReg()
        {
            User newUser = new User(Role.Member);
            CollectData(newUser);
        }

        public static void CollectData(User newUser)
        {
            var NewUser = newUser;
            Console.WriteLine("To sign up enter the following details...");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine();
            Console.Write("Firstname: ");
            NewUser.FirstName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Lastname: ");
            NewUser.LastName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Email: ");
            var email = (Console.ReadLine()).ToLower();
            while (Validation.ValidateEmail(email) != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid email!!!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Email: ");
                email = (Console.ReadLine()).ToLower();
            }
            NewUser.UserEmail = email;

            Console.WriteLine();
            Console.Write("Phonenumber: ");
            var phoneNumber = Utilities.CollectNumbers();
            while (Validation.ValidatePhoneNumber(phoneNumber) != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid phoneNumber!!!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Phonenumber: ");
                phoneNumber = Utilities.CollectNumbers();
            }
            NewUser.PhoneNumber.Add(phoneNumber);

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Add another phonenumber or tap the enter key to continue...");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Phonenumber: ");

                phoneNumber = Utilities.CollectNumbers();

                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    break;
                }

            }
            while (!string.IsNullOrWhiteSpace(phoneNumber));

            ClearLinesAbove(2);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.Write("Password: ");
            var password = Utilities.CollectSecretData();
            while (password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must be at least 6 characters!!!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Password: ");
                password = Utilities.CollectSecretData();
            }
            NewUser.Password = password;

            Console.WriteLine();
            Console.ResetColor();
            Console.Write("Will you like to set a username??? If yes enter 'y' >>> ");
            var reply = Console.ReadLine();
            string userName;
            Console.WriteLine();
            if (reply == "y")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Username: ");
                userName = Console.ReadLine();
            }
            else
            {
                userName = null;
            }
            NewUser.userName = userName;

            Database.Users.Add(NewUser);


            Console.Clear();
            Program.Next();
        }

        public static void ClearLinesAbove(int numberOfLines = 1)
        {
            Console.WriteLine();
            int currentLineCursor = Console.CursorTop - numberOfLines;
              
            Console.SetCursorPosition(0, currentLineCursor);
            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
