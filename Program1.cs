using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using static System.Console;


namespace Final_Project_C___airplane_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AirplaneSimulator simulator = new AirplaneSimulator();
                simulator.RunSimulation();
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}



