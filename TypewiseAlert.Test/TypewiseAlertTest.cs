using System;
using Xunit;
using static TypewiseAlert.AlertTargetType;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(BreachTypeAlert.InferBreach(12, 20, 30) ==
        BreachTypeAlert.BreachType.TOO_LOW);
    }
    [Fact]
     public void ClassifyTemperatureBreachLimits()
     {
            Assert.True(CoolingTypeAlert.ClassifyTemperatureBreach(CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING, 40) ==
              BreachTypeAlert.BreachType.NORMAL);
     }
    [Fact]
    public static void CheckAndAlertFunctionalityTests()
    {
           BatteryCharacter batterychar = new BatteryCharacter();
            batterychar.brand = "BOSCH";
            batterychar.coolingType = CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING;
            
             Assert.True(AlertTargetType.CheckAndAlert(AlertTarget.TO_CONTROLLER, batterychar, 10) ==
             true);
    }
  }
}
