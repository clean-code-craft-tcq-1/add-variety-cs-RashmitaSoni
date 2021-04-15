using System;
using Xunit;
using static TypewiseAlert.AlertTargetType;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void TestInfersBreachAsPerLimits()
    {
      Assert.True(BreachTypeAlert.InferBreach(12, 20, 30) == BreachTypeAlert.BreachType.TOO_LOW);
    }
    [Fact]
     public void TestClassifyTemperatureBreachLimits()
     {
            Assert.True(CoolingTypeAlert.ClassifyTemperatureBreach(CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING, 40) == BreachTypeAlert.BreachType.NORMAL);
     }
    [Fact]
    public static void TestControllerNotifier()
        {
            FakeSentToController callfakecontroller = new FakeSentToController();
            callfakecontroller.GetAlertType(BreachTypeAlert.BreachType.NORMAL);
            Assert.True(FakeSentToController.IsFakeSentToControllerInvoked);
        }
    [Fact]
    public static void TestEmailNotifier()
        {
            FakeSentToEmail callfakeemail = new FakeSentToEmail();
            callfakeemail.GetAlertType(BreachTypeAlert.BreachType.NORMAL);
            Assert.True(FakeSentToEmail.IsFakeSentToEmailInvoked);
        }
    [Fact]
    public static void TestConsoleNotifier()
        {
            FakeSentToConsole callfakeconsole = new FakeSentToConsole();
            callfakeconsole.GetAlertType(BreachTypeAlert.BreachType.NORMAL);
            Assert.True(FakeSentToConsole.IsFakeSentToConsoleInvoked);
        }
  }
}
