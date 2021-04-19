using System;
using System.Collections.Generic;
using static TypewiseAlert.AlertTypes;
using static TypewiseAlert.BreachTypeAlert;

namespace TypewiseAlert
{
   public class AllAlertTypes : IAlertType
    {
        List<IAlertType> alerttypes = new List<IAlertType>();
        public void CallAlertTartgetType(BreachType breachType)
        {
            foreach (IAlertType type in alerttypes)
            {
                type.CallAlertTartgetType(breachType);
            }
        }

        public void AddToAlertTargetTypeList(IAlertType type)
        {
            alerttypes.Add(type);
        }
    }
}
