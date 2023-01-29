using System;
using System.Collections.Generic;
using System.Text;

namespace PeapoolApp.BL
{
    public static class Validation
    {
        public static bool ValidateEmail(string email)
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                var i = 0;
                while (i < email.Length)
                {
                    if (!Char.IsWhiteSpace(email[i]))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (long.TryParse(phoneNumber, out _) && phoneNumber.Length == 11)
            {
                return true;
            }
            else return false;
        }
    }
}
