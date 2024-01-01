using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C___airplane_
{
    public class PlaneCrashException : Exception
    {
        public PlaneCrashException(string message) : base(message) { }
    }

    public class DescendedToTheVoid : Exception
    {
        public DescendedToTheVoid(string message) : base(message) { }
    }

    public class SpeedLimit : Exception
    {
        public SpeedLimit(string message) : base(message) { }
    }

    public class HighAltitudeLowSpeed : Exception
    {
        public HighAltitudeLowSpeed(string message) : base(message) { }
    }

    class UnfitForFlightException : Exception
    {
        public UnfitForFlightException(string message) : base(message) { }
    }
}
