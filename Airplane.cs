
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Final_Project_C___airplane_
{
    public class Airplane
    {
        public int Speed { get; private set; }
        public int Altitude { get; private set; }
        public AirplaneSimulator simulator;

        public delegate void SpeedAltitudeChangeHandler(int speed, int altitude);
        public event SpeedAltitudeChangeHandler SpeedAltitudeChanged;

        public List<Controller> Controllers { get; private set; } = new List<Controller>();

        public void AddController(Controller controller)
        {
            Controllers.Add(controller);
            SpeedAltitudeChanged += controller.OnSpeedAltitudeChanged;
        }

        public void RemoveController(Controller controller)
        {
            Controllers.Remove(controller);
            SpeedAltitudeChanged -= controller.OnSpeedAltitudeChanged;
        }

        public void ChangeSpeed(int delta)
        {
            Speed += delta;

            // Check for conditions, such as exceeding maximum speed
            // You can add more conditions as needed
            if (Speed < 0)
            {
                throw new DescendedToTheVoid($"Plane reached -1 km/h, therefore descended to the void");
            }

            if (Speed >= 1000)
            {
                SetCursorPosition(0, 25);
                WriteLine($"1000km/h reached. Please descent ground.");
            }


            NotifyControllers();
        }


        public void ChangeAltitude(int delta)
        {
            int speedAltitudeDifference = Altitude - Speed;
            // Check for conditions, such as negative altitude or zero altitude with zero speed
            if (Altitude < 0)
            {
                foreach (var controller in Controllers)
                {
                    controller.HandleCrash();
                }
            }
            else if (Speed == 0 && Altitude > 0)
            {
                WriteLine("Cannot ascend with zero speed. Penalty points added.");
                foreach (var controller in Controllers)
                {
                    controller.AddPenaltyPoint(100); // Adjust the penalty points as needed
                }
            }
            else if (speedAltitudeDifference > 7000)
            {
                throw new UnfitForFlightException($"Unfit for flight.");
            }
            else
            {
                Altitude += delta;
            }



            NotifyControllers();
        }

        private void NotifyControllers()
        {
            SpeedAltitudeChanged?.Invoke(Speed, Altitude);
        }
    }
}
