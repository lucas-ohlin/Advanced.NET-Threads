using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Threads_Labb.UserInterface {

    internal class ApplicationUI {

        public static void Run() {

            while (ApplicationMethods.racing) {

                Console.WriteLine("\n" +
                    "start. Start the race, starts the initial threads.\r\n" +
                    "check. Check status of the cars in the race\r\n" +
                    "exit. Close the application.\r\n" 
                );

                string input = Console.ReadLine();

                switch (input.ToLower()) {
                    default:
                        Console.WriteLine("Not a valid command.");
                        ApplicationMethods.Enter();
                        break;
                    case "start":
                        ApplicationMethods.RacingSetup();
                        ApplicationMethods.Enter();
                        break;
                    case "check":
                        ApplicationMethods.CheckStatus();
                        ApplicationMethods.Enter();
                        break;
                    case "exit":
                        ApplicationMethods.racing = false;
                        Console.WriteLine("Closing the application...");
                        break;
                }

            }

        }

    }

}
