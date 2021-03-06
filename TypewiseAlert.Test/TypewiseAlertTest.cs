using System;
using Xunit;
using static TypewiseAlert.AlertTargetType;
using static TypewiseAlert.AlertTypes;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void TestInfersBreachAsLowLimits()
    {
      Assert.True(BreachTypeAlert.InferBreach(12, 20, 30) == BreachTypeAlert.BreachType.TOO_LOW);
    }
    [Fact]
    public void TestInfersBreachAsHighLimits()
    {
      Assert.True(BreachTypeAlert.InferBreach(38, 20, 30) == BreachTypeAlert.BreachType.TOO_HIGH);
    }
    [Fact]
    public void TestInfersBreachAsNormalLimits()
    {
      Assert.True(BreachTypeAlert.InferBreach(25, 20, 30) == BreachTypeAlert.BreachType.NORMAL);
    }
    [Fact]
     public void TestClassifyTemperatureBreachHighCoolingLimits()
     {
            Assert.True(CoolingTypeAlert.ClassifyTemperatureBreach(CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING, 40) == BreachTypeAlert.BreachType.NORMAL);
     }
    [Fact]
     public void TestClassifyTemperatureBreachMeduimCoolingLimits()
     {
            Assert.True(CoolingTypeAlert.ClassifyTemperatureBreach(CoolingTypeAlert.CoolingType.MED_ACTIVE_COOLING, 45) == BreachTypeAlert.BreachType.TOO_HIGH);
     }
    [Fact]
     public void TestClassifyTemperatureBreachLowCoolingLimits()
     {
            Assert.True(CoolingTypeAlert.ClassifyTemperatureBreach(CoolingTypeAlert.CoolingType.PASSIVE_COOLING, -2) == BreachTypeAlert.BreachType.TOO_LOW);
     }
    [Fact]
      public void TestSetEmailMessagesForHighBreachType()
      {
          var emailMessageType = new SetEmailMessagesForBreachType().Email[BreachTypeAlert.BreachType.TOO_HIGH]();
          Assert.NotNull(emailMessageType);
      }
     [Fact]
      public void TestSetEmailMessagesForLowBreachType()
      {
          var emailMessageType = new SetEmailMessagesForBreachType().Email[BreachTypeAlert.BreachType.TOO_LOW]();
          Assert.NotNull(emailMessageType);
      }
     [Fact]
      public void TestSetEmailMessagesForNormalBreachType()
      {
          var emailMessageType = new SetEmailMessagesForBreachType().Email[BreachTypeAlert.BreachType.NORMAL]();
          Assert.NotNull(emailMessageType);
      }
    [Fact]
      public void TestMailHighBreachTypeInfo()
      {
          var isException = Record.Exception(() => new MailHighBreachTypeInfo().GetEmailContent("test@mail.com", BreachTypeAlert.BreachType.TOO_HIGH));
          Assert.Null(isException);
      }
     [Fact]
      public void TestMailLowBreachTypeInfo()
      {
          var isException = Record.Exception(() => new MailLowBreachTypeInfo().GetEmailContent("test@mail.com", BreachTypeAlert.BreachType.TOO_LOW));
          Assert.Null(isException);
      }
      [Fact]
      public void TestMailNormalBreachTypeInfo()
      {
          var isException = Record.Exception(() => new MailNormalStateInfo().GetEmailContent("test@mail.com", BreachTypeAlert.BreachType.NORMAL));
          Assert.Null(isException);
      }
    [Fact]
    public static void TestControllerNotifier()
        {
            BatteryCharacter batterychar = new BatteryCharacter();
            batterychar.brand = "BOSCH";
            batterychar.coolingType = CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING;
            FakeSentToController alertTarget = new FakeSentToController();
            CheckAndAlert(alertTarget, batterychar, 10);
            Assert.True(FakeSentToController.IsFakeSentToControllerInvoked == true);
        }
    [Fact]
    public static void TestEmailNotifier()
        {
            BatteryCharacter batterychar = new BatteryCharacter();
            batterychar.brand = "BOSCH";
            batterychar.coolingType = CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING;
            FakeSentToEmail alertTarget = new FakeSentToEmail();
            CheckAndAlert(alertTarget, batterychar, 10);
            Assert.True(FakeSentToEmail.IsFakeSentToEmailInvoked == true);
        }
    [Fact]
    public static void TestConsoleNotifier()
        {
            BatteryCharacter batterychar = new BatteryCharacter();
            batterychar.brand = "BOSCH";
            batterychar.coolingType = CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING;
            FakeSentToConsole alertTarget = new FakeSentToConsole();
            CheckAndAlert(alertTarget, batterychar, 10);
            Assert.True(FakeSentToConsole.IsFakeSentToConsoleInvoked == true);
        }
    [Fact]
      public static void TestCompositeCheckAndAlert()
        {
            var alerttype = new AllAlertTypes();
            FakeSentToController callfakecontroller = new FakeSentToController();
            FakeSentToEmail callfakeemail = new FakeSentToEmail();
            FakeSentToConsole callfakeconsole = new FakeSentToConsole();
            alerttype.AddToAlertTargetTypeList(callfakecontroller);
            alerttype.AddToAlertTargetTypeList(callfakeemail);
            alerttype.AddToAlertTargetTypeList(callfakeconsole);
            BatteryCharacter batterychar = new BatteryCharacter();
            batterychar.brand = "BOSCH";
            batterychar.coolingType = CoolingTypeAlert.CoolingType.HI_ACTIVE_COOLING;
            CheckAndAlert(alerttype, batterychar, 10);
            Assert.True(FakeSentToController.IsFakeSentToControllerInvoked && FakeSentToEmail.IsFakeSentToEmailInvoked && FakeSentToConsole.IsFakeSentToConsoleInvoked);
        }
  }
}
