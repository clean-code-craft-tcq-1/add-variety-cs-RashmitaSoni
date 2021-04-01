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
    public void ReportEmailNotification()
    {
      BatteryCharacter batteryChar = new BatteryCharacter();
      batteryChar.coolingType = PASSIVE_COOLING;
      batteryChar.brand = "Test";
      Assert.True(AlertTargetType.CheckAndAlert(AlertTargetType.AlertTarget.TO_EMAIL,AlertTargetType.BatteryCharacter.batteryChar,30) ==
        "Sent");
    }
  }
}
