using System;
using System.Collections.Generic;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public class CoolingTypeAlert
    {
        public enum CoolingType
        {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };
        public static BreachType ClassifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            CoolingEndLimits coolingEndLimits = new SetCoolingTypeLimit().CoolingTypes[coolingType]().InitializeCoolingLimit(coolingType);
            return InferBreach(temperatureInC, coolingEndLimits.lowerLimit, coolingEndLimits.upperLimit);
        }
        
    }
    public class SetCoolingTypeLimit
        {
            public Dictionary<CoolingType, Func<IInitializeCoolingLimits>> CoolingTypes = new Dictionary<CoolingType, Func<IInitializeCoolingLimits>>();

            public SetCoolingTypeLimit()
            {
                CoolingTypes.Add(CoolingType.PASSIVE_COOLING, () => { return new PassiveCoolingEndLimits(); });
                CoolingTypes.Add(CoolingType.HI_ACTIVE_COOLING, () => { return new HighCoolingEndLimits(); });
                CoolingTypes.Add(CoolingType.MED_ACTIVE_COOLING, () => { return new MediumCoolingEndLimits(); });
            }
        }
}
