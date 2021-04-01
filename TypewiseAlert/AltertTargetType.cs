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
            TO_EMAIL
        };
        public struct BatteryCharacter
        {
            public CoolingType coolingType;
            public string brand;
        }
        public static void CheckAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            string result = new AlertTargetTypes(breachType).AlertTargetType[alertTarget];
        }
    }
    public class AlertTargetTypes
    {
        public Dictionary<AlertTarget, String> AlertTargetType = new Dictionary<AlertTarget, String>();
        public AlertTargetTypes(BreachType breachType)
        {
            AlertTargetType.Add(AlertTarget.TO_CONTROLLER, SendToController(breachType));
            AlertTargetType.Add(AlertTarget.TO_EMAIL, SendToEmail(breachType));
        }
        public static String SendToController(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{} : {}\n", header, breachType);
            return "Sent";
        }

        public static String SendToEmail(BreachType breachType)
        {
            string recepient = "a.b@c.com";
            new SetEmailMessagesForBreachType().Email[breachType]().GetEmailContent(recepient, breachType);
            return "Sent";
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
