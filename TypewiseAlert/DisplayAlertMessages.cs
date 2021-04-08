using System;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public static class DisplayBreachTypeInfo
    {
        public static void DisplayContent(BreachType BreachType)
        {
            Console.WriteLine("Temperature is {0}\n",BreachType);
        }
    }
}
