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
    public void ReportWhenSentToContoller()
    {
      Assert.True(AlertTargetTypes.SendToController(BreachTypeAlert.BreachType.TOO_LOW) ==
        "Sent");
    }
  }
}
