using System;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public interface IDisplayContent
    {
        void DisplayContent(BreachType BreachType);
    }

    class DisplayLowBreachTypeInfo : IDisplayContent
    {
        public void DisplayContent(BreachType BreachType)
        {
            Console.WriteLine("Hi, the temperature is too low\n");
        }
    }

    class DsiplayHighBreachTypeInfo : IDisplayContent
    {
        public void DisplayContent(BreachType BreachType)
        {
            Console.WriteLine("Hi, the temperature is too high\n");
        }
    }

    class DisplayNormalStateInfo : IDisplayContent
    {
        public void DisplayContent(BreachType BreachType)
        {
            Console.WriteLine("Hi, the temperature is in normal state\n");
        }
    }
}
