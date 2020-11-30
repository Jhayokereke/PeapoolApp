using System;

namespace PeapoolApp.BL
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                var welcomeMessage = "Hello\nWelcome to Peapool\nEnter \'Help\' to view the help tab.";

                Console.WriteLine(welcomeMessage);
                Console.Write("");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                    break;
            
                switch (input)
                {
                    case Input.Help:
                        Console.WriteLine(help);
                        break;
                    case Input.login:
                        Console.WriteLine("");
                        break;

                }

            }
            
        }

        public string Help
        {
            get { input }
        }
    }
}
