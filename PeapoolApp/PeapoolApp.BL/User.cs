using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PeapoolApp.BL
{
    public class User
    {
        public User(string firstName)
        {
            FirstName = firstName;
            userID = GenerateUserID();
        }
        private string userID;
        public string UserID
        { 
            get { return userID; } 
        }
        public string Name
        {
            get
            {
                string name = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        name += ", ";
                    }
                    name += FirstName;
                }
                return name;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private string Role { get; set; }
        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            private set
            {
                _dateCreated = DateTime.Now;
            }
        }

        private string[] phoneNumber;

        public string[] GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void SetPhoneNumber(string[] value)
        {
            phoneNumber = value;
        }

        private string GenerateUserID()
        {
            var userID = "PeaPL.ahJ";
            const int uniqueUserIDlength = 6;
            var random = new Random();
            var uniqueUserID = new char[uniqueUserIDlength];
            for (var i = 0; i < uniqueUserIDlength; i++)
            {
                uniqueUserID[i] = (char)random.Next(9999);
            }
                userID += new string(uniqueUserID);
            return userID;
        }


    }
}
