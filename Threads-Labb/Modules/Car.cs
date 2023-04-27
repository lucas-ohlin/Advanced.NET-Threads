using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads_Labb.UserInterface;

namespace Threads_Labb.Modules {

    internal class Car {

        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        
        //If this bool is static it will affect all instances of the class
        //Hence why it's not :)
        public bool driving = true;

        public Car(string name, int speed, int distance) {
            this.Name = name;
            this.Speed = speed;
            this.Distance = distance;
        }

        public void Check() {
            Console.WriteLine($"{Name}\n    Speed : {Speed}km/h \tDistance : {Distance}");
        }

        public void Drive() {

            if (driving) {
                var timer = new Timer(Move, null, 0, 1 * 1000);
            }

        }

        private void Move(object? state) {

            //The speed the car travels each sec
            Distance = (Distance + Speed / 10);

            //Check if the car has driven more than the goal and it's already not in the list
            if (Distance >= ApplicationMethods.goal && !ApplicationMethods.winningList.Contains(this)) {
                //Adds this car to the winningList of cars that has reached ths goal
                ApplicationMethods.ReachedGoal(this);
                Speed = 0;
                driving = false;
            }

        }

        public async void CarStop(int time) {

            //Stop the car 
            driving = false;
            //Lets this thread sleep for te time given 
            Thread.Sleep(time);

            driving = true;
            Console.WriteLine($"{Name} starts...");

        }

        public void RandomEvent() {

            //Generate the random number
            int rng = new Random().Next(1, 50);

            if (rng == 1) {
                Console.WriteLine($"{Name} is out of fuel! | stops for 30 sec");
                CarStop(30000);
            }
            else if (rng >= 2 && rng <= 4) { 
                Console.WriteLine($"{Name} had a flat tire! | stops for 20 sec");
                CarStop(20000);
            }
            else if (rng >= 5 && rng <= 10) {
                Console.WriteLine($"{Name}'s car has bird poop on it's windshield! | stops for 10 sec");
                CarStop(10000);
            }    
            else if (rng >= 40 && rng <= 50) {
                Console.WriteLine($"{Name} had an engine faults! | speed is lowered by 1km/h");
                Speed--;
            }
            else
                Console.WriteLine($"{Name}'s car had no faults this event.");

        }

    }

}
