using System;
using System.Collections.Generic;
using System.Text;

namespace PeapoolApp.BL
{
    class Validation
    {
        public static bool ValidatePhoneNumber()
        {
            var validPhoneNumber = true;
            var errorMsg1 = "Please enter a valid number";
            var numberAsString = Console.ReadLine();
            if (long.TryParse(numberAsString, out _))
                return validPhoneNumber;
        }

        public static bool ValidateEmail()
        {
            var validEmail = true;

        }
    }
}
