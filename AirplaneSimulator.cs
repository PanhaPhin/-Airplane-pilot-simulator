
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Final_Project_C___airplane_
{
    public class AirplaneSimulator
    {
        private Airplane airplane;



        public AirplaneSimulator()
        {
            airplane = new Airplane();
            InitializeControllers();
        }



        private void InitializeControllers()
        {
            WriteLine("Enter information for at least two controllers:");

            while (airplane.Controllers.Count < 2)
            {
                Write("Enter Controller name: ");
                string name = ReadLine();

                Controller controller = new Controller(name);
                airplane.AddController(controller);
            }
        }



        private void airplaneGuide()
        {


            WriteLine("Guide:");
            WriteLine(" - Use Arrow keys to control the airplane's speed and altitude.");
            WriteLine("   - Right Arrow: Increase speed by 50 km/h (Shift + Right Arrow: Increase speed by 150 km/h)");
            WriteLine("   - Left Arrow: Decrease speed by 50 km/h (Shift + Left Arrow: Decrease speed by 150 km/h)");
            WriteLine("   - Up Arrow: Increase altitude by 250 meters (Shift + Up Arrow: Increase altitude by 500 meters)");
            WriteLine("   - Down Arrow: Decrease altitude by 250 meters (Shift + Down Arrow: Decrease altitude by 500 meters)");
            WriteLine(" - Press 'A' to add a new air traffic controller.");
            WriteLine(" - Press 'R' to remove an existing air traffic controller.");
            WriteLine(" - The simulation ends when you decide to exit or when reaching 1000km/h and reaching the ground.");
            WriteLine();
        }

        private void DisplayControllersInfo()
        {
            WriteLine("\nCurrent Flight Status:");
            WriteLine($" - Altitude: {airplane.Altitude} meters");
            WriteLine($" - Speed: {airplane.Speed} km/h");
            WriteLine();

        }

        public void RunSimulation()
        {
            airplaneGuide();
            WriteLine("Simulation started. Press Q to quit.");
            WriteLine();
            WriteLine("Press the RIGHTARROW key to start the plane.");

            while (true)
            {
                SetCursorPosition(0, 17);

                ConsoleKeyInfo key = ReadKey(true);
                HandleKey(key);
                WriteLine();
                DisplayControllersInfo();

                /*if (airplane.Speed >= 1000)
                {
                   while (true)
                    {
                    SetCursorPosition(0, 25);
                    ConsoleKeyInfo Descentkey = ReadKey(true);
                        HandleDescentKey(Descentkey);
                        WriteLine();
                        DisplayControllersInfo();

                        WriteLine($"1000km/h reached. Please descent ground.");
                        WriteLine("Press the LEFTARROW key to decrease speed");
                        WriteLine("Press the DOWNARROW to decrease altitude");


                    if (airplane.Speed > 1100)
                        {
                          throw new UnfitForFlightException($"Unfit for flight.");
                        }

                        if (airplane.Speed == 0 && airplane.Altitude == 0)
                        {
                            WriteLine("Congratulations. You successfully landed the plane");
                            break;
                        }




                    }

                }*/





                // Add other simulation logic or conditions here

                // For simplicity, we break out of the loop when Q is pressed
                if (KeyAvailable && ReadKey(true).Key == ConsoleKey.Q)
                    break;
            }

            WriteLine("Simulation ended. Displaying results...");
            DisplayResults();
        }



        private void HandleKey(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    airplane.ChangeSpeed(key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? 150 : 50);

                    break;

                case ConsoleKey.LeftArrow:
                    airplane.ChangeSpeed(key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? -150 : -50);
                    break;

                case ConsoleKey.UpArrow:
                    airplane.ChangeAltitude(key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? 500 : 250);
                    break;

                case ConsoleKey.DownArrow:
                    airplane.ChangeAltitude(key.Modifiers.HasFlag(ConsoleModifiers.Shift) ? -500 : -250);
                    break;

                case ConsoleKey.A:
                    AddController();
                    break;

                case ConsoleKey.R:
                    RemoveController();
                    break;

                default:
                    break;
            }
        }



        private void AddController()
        {
            Write("Enter Controller name: ");
            string name = ReadLine();

            Controller controller = new Controller(name);
            airplane.AddController(controller);
        }

        private void RemoveController()
        {
            if (airplane.Controllers.Count > 2)
            {
                Write("Enter Controller name to remove: ");
                string name = ReadLine();

                Controller controllerToRemove = airplane.Controllers.Find(c => c.GetName() == name);

                if (controllerToRemove != null)
                {
                    airplane.RemoveController(controllerToRemove);
                    WriteLine($"Controller {name} removed.");
                }
                else
                {
                    WriteLine($"Controller {name} not found.");
                }
            }
            else
            {
                WriteLine("Cannot remove controllers. The aircraft must be controlled by at least two controllers.");
            }
        }

        private void DisplayResults()
        {
            WriteLine("Final results:");

            foreach (var controller in airplane.Controllers)
            {
                WriteLine($"Controller: {controller.GetName()}, Penalty Points: {controller.GetPenaltyPoints()}");
            }

            int totalPenaltyPoints = airplane.Controllers.Sum(c => c.GetPenaltyPoints());
            WriteLine($"Total Penalty Points: {totalPenaltyPoints}");
        }
    }
}
