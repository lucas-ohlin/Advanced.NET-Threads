using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Threads_Labb.Modules;

namespace Threads_Labb.UserInterface {

    internal class ApplicationMethods {

        //Used in ApplicationUI
        public static bool racing = true;

        public static int goal = 500;

        //create the cars
        public static Car car1 = new Car("Blixten", 120, 0);
        public static Car car2 = new Car("Andra", 120, 0);

        //add them to a list
        public static List<Car> carList = new List<Car> { 
            car1, 
            car2 
        };

        //winning list
        public static List<Car> winningList = new List<Car>();

        public static void ReachedGoal(Car car) {

            if (winningList.Count == 0)
                Console.WriteLine(car.Name + " came in 1st place!");

            winningList.Add(car);

            if (winningList.Count == carList.Count)
                Console.WriteLine($"Race is finished. {winningList[0].Name} Won");

        }

        public static void CheckStatus() {
            Console.WriteLine("");
            foreach (Car car in carList)
                car.Check();
            Console.WriteLine("Reached the goal : " + winningList.Count);
        }

        public static void RacingSetup() {
            StartThreads();
        }

        private static void StartThreads() {

            Console.WriteLine("---THE RACE STARTS---");

            //Initialize the threads
            Thread timerThread = new Thread(new ThreadStart(GlobalTimer));
            timerThread.Start();

            //thread with paremeters
            Thread carThread1 = new Thread(() => RaceThread(car1));
            carThread1.Start();

            Thread carThread2 = new Thread(() => RaceThread(car2));
            carThread2.Start();

        }

        private static void RaceThread(Car car) {
            car.Drive();
        }

        private static void GlobalTimer() {
            //Call the EventHandler method every x sec
            var timer = new Timer(EventHandler, null, 0, 30 * 1000);
        }

        private static void EventHandler(object o) {

            Console.WriteLine("\nEvent : " + DateTime.Now);

            foreach (Car car in carList) {
                //If the car hasn't already stopped
                if (car.driving)
                    car.RandomEvent();
            }

        }

        public static void Enter() {

            Console.WriteLine("\nPress Enter to continue");

            //Gets the key that's pressed
            ConsoleKeyInfo e;
            do {
                e = Console.ReadKey();
            } while (e.Key != ConsoleKey.Enter);
            Console.Clear();

        }

    }

}
