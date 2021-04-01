using System;

namespace TypewiseAlert
{
    public class BreachTypeAlert
    {
        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };
        public static BreachType InferBreach(double value, double lowerLimit, double upperLimit)
        {
            return (value < lowerLimit) ? BreachType.TOO_LOW :
                   (value > upperLimit) ? BreachType.TOO_HIGH :
                                          BreachType.NORMAL;
        }   
    }
}
