using System;
using System.Collections.Generic;
using System.Linq;

namespace PeapoolApp.BL
{
    public class User
    {
        public User(Role role)
        {
            userRole = role.ToString();
            Random randomId = new Random();
            userID = $"Peapl.Ng-{userRole}.{randomId.Next(9999)}";
            dateCreated = DateTime.Now;
        }

        public string userID;

        public DateTime dateCreated;

        public string userRole;

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(LastName))
                    {
                        fullName += " ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public List<string> PhoneNumber { set; get; } = new List<string>();

        public string UserEmail { set; get; }
        
        public string Password { set; get; }

        public string userName;

        public override string ToString()
        {
            return "ID: " + userID + "\nName: " + FullName + "\nEmail: " + UserEmail + "\nPassword: " + Password + "\nRole: " + userRole + "\nDatedCreated: " + dateCreated + "\nPhonenumber: " + string.Join(", ", PhoneNumber);
        }

        public static void PrintData()
        {
            if (UseApp.CurrentUser.userRole == "Admin")
            {
                foreach (User user in Database.Users)
                {
                    Console.WriteLine();
                    Console.WriteLine("Existing users include...");
                    Console.WriteLine(user);
                    Console.WriteLine();
                }
                Console.ReadLine();
                UseApp.LoggedIn();
            }
            else Console.WriteLine("Sorry, you are not an admin");
            UseApp.LoggedIn();
        }
    }

    public static class Database
    {
        public static List<User> Users { get; set; } = new List<User>();
    }
}