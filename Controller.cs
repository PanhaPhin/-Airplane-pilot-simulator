using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Final_Project_C___airplane_
{
    public class Controller
    {
        private readonly string name;
        private readonly int weatherConditionAdjustment;
        private Airplane airplane;


        private int penaltyPoints { get; set; }

        public Controller(string name)
        {
            this.name = name;
            Random random = new Random();
            weatherConditionAdjustment = random.Next(-200, 200);
        }

        internal string GetName()
        {
            return name;
        }


        public void Notify(Airplane airplane)
        {
            // Retrieve altitude and speed from the airplane
            int currentAltitude = airplane.Altitude;
            int currentSpeed = airplane.Speed;
        }

        public void OnSpeedAltitudeChanged(int speed, int altitude)
        {
            int recommendedAltitude = 7 * speed - weatherConditionAdjustment;
            int altitudeDifference = recommendedAltitude - altitude;

            // Check altitude difference conditions

            if (altitudeDifference > 600 && altitudeDifference <= 1000)
            {
                penaltyPoints += 25;
            }
            else if (altitudeDifference > 1000)
            {
                throw new PlaneCrashException($"Plane crashed due to large altitude difference. Controller: {name}");
            }

            // Check penalty points conditions
            if (penaltyPoints >= 1000)
            {
                throw new UnfitForFlightException($"Unfit for flight due to excessive penalty points. Controller: {name}");
            }

            // Display information on the screen

            WriteLine($"Controller: {name}, Recommended Altitude: {recommendedAltitude}, Penalty Points: {penaltyPoints}");
        }

        public void ChargePenalty(int points)
        {
            penaltyPoints += points;
            WriteLine($"Penalty charged by Controller {name}: {points} points");
        }

        public void HandleCrash()
        {
            throw new PlaneCrashException($"Plane crashed. Controller: {name}");
        }

        public void AddPenaltyPoint(int point)
        {
            penaltyPoints += point;
        }
        public int GetPenaltyPoints()
        {
            return penaltyPoints;
        }
    }
}
