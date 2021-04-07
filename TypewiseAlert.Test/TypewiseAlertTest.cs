using System;
using Xunit;

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
  }
}
