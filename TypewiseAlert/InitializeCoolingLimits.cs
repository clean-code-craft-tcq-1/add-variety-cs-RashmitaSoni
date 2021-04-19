using System;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public class CoolingEndLimits
    {
        public int lowerLimit { get; set; }
        public int upperLimit { get; set; }
    }

    public interface IInitializeCoolingLimits
    {
        CoolingEndLimits InitializeCoolingLimit(CoolingType coolingType);
    }

    class PassiveCoolingEndLimits : IInitializeCoolingLimits
    {
        public CoolingEndLimits InitializeCoolingLimit(CoolingType coolingType)
        {
            return new CoolingEndLimits()
            {
                lowerLimit = 0,
                upperLimit = 35
            };
        }
    }

    class HighCoolingEndLimits : IInitializeCoolingLimits
    {
        public CoolingEndLimits InitializeCoolingLimit(CoolingType coolingType)
        {
            return new CoolingEndLimits()
            {
                lowerLimit = 0,
                upperLimit = 45
            };
        }
    }

    class MediumCoolingEndLimits : IInitializeCoolingLimits
    {
        public CoolingEndLimits InitializeCoolingLimit(CoolingType coolingType)
        {
            return new CoolingEndLimits()
            {
                lowerLimit = 0,
                upperLimit = 35
            };
        }
    }
}
