using System;
using System.Collections.Generic;
using static TypewiseAlert.AlertTargetType;
using static TypewiseAlert.AlertTypes;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public class AlertTargetType
    {
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
        }
        public static void CheckAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            var alertFactory = new AlertFactory();
            var type = alertFactory.GetAlertBasedOnTargetType(alertTarget);
            type.CallAlertTartgetType(breachType);
        }
    }
    public class AlertTargetTypes
    {
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
        public static void SendToConsole(BreachType breachType)
        {
            DisplayBreachTypeInfo.DisplayContent(breachType);
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

        public static void DisplayEmailContent(string Recepient, BreachType BreachType)
        {
            Console.WriteLine("To: {0}\n", Recepient);
            Console.WriteLine("Hi, the temperature is {0}\n",BreachType);
        }
    }
}
