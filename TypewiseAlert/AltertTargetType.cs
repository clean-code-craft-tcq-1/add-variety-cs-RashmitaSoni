using System;
using System.Collections.Generic;
using static TypewiseAlert.AlertTargetType;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public class AlertTargetType
    {
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL,
            TO_CONSOLE,
            TO_TESTEMAIL //For Unit Testing
        };
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
        }
        public static void CheckAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            new AlertTargetTypes(breachType).AlertTargetType[alertTarget]();
        }
    }
    public class AlertTargetTypes
    {
        public Dictionary<AlertTarget, Action> AlertTargetType = new Dictionary<AlertTarget, Action>();
        public AlertTargetTypes(BreachType breachType)
        {
            AlertTargetType.Add(AlertTarget.TO_CONTROLLER, (() =>SendToController(breachType)));
            AlertTargetType.Add(AlertTarget.TO_EMAIL, (() =>SendToEmail(breachType)));
            AlertTargetType.Add(AlertTarget.TO_CONSOLE, (() =>DisplayToConsole(breachType)));
            AlertTargetType.Add(AlertTarget.TO_TESTEMAIL, (() =>TestFakeEmail(breachType)));
        }
        public static void SendToController(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{0} : {1}\n", header, breachType);
        }

        public static void SendToEmail(BreachType breachType)
        {
            string recepient = "a.b@c.com";
            new SetEmailMessagesForBreachType().Email[breachType]().GetEmailContent(recepient, breachType);
        }
        public static void DisplayToConsole(BreachType breachType)
        {
            DisplayBreachTypeInfo.DisplayContent(breachType);
        }
        public static void TestFakeEmail(BreachType breachType)
        {
            string recepient = "test.fake@email.com";
            new FakeMailStateInfo().GetEmailContent(recepient, breachType);
        }
    }
    public class SetEmailMessagesForBreachType
    {
        public Dictionary<BreachType, Func<IInitializeEmailContent>> Email = new Dictionary<BreachType, Func<IInitializeEmailContent>>();

        public SetEmailMessagesForBreachType()
        {
            Email.Add(BreachType.TOO_HIGH, () => { return new MailHighBreachTypeInfo(); });
            Email.Add(BreachType.TOO_LOW, () => { return new MailLowBreachTypeInfo(); });
            Email.Add(BreachType.NORMAL, () => { return new MailNormalStateInfo(); });
        }
    }
}
