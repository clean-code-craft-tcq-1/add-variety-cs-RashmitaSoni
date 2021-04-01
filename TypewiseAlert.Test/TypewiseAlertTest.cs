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
      Assert.True(AlertTargetType.CheckAndAlert(AlertTargetType.AlertTarget.TO_EMAIL,CoolingTypeAlert.CoolingType.PASSIVE_COOLING,30) ==
        "Sent");
    }
  }
}
