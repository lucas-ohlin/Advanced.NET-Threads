using Threads_Labb.Modules;
using Threads_Labb.UserInterface;

namespace Threads_Labb {

    //All cars start at the same time               [DONE]
    //Write to console when the race starts         [DONE]
    //Write to console when a problem occours       [DONE]
    //Write to console when a car reaches the goal  []
    //User should be able press / or type out       []
    // somethign to get the current                 
    // status of each car in the race

    // CAR [DONE]
    //Default speed : 120km/h                       [DONE]
    //Every 30 sec an event occours:                [DONE]
    // 1/50  Out of fuel   : stop for 30 sec        [DONE]
    // 2/50  Flat tire     : stop for 20 sec        [DONE]
    // 5/50  Birdshit      : stop for 10 sec        [DONE]
    // 10/50 Engine faults : Lower speed with 1km/h [DONE]

    // Race
    //Lenght of the race is 10km                    []
    //All cars start at 0km                         [DONE]
    //No acceleration, from 0 to 120km/h in 0 sec   [DONE]
    //All cars are on their own threads             [DONE]


    internal class Program {

        static void Main(string[] args) {

            ApplicationUI.Run();

        }

    }

}