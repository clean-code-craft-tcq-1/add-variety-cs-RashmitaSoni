using System;
using System.Collections.Generic;
using static TypewiseAlert.AlertTargetType;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public class AlertTypes
    {
        public enum AlertTarget
        {
            TO_CONTROLLER,
            TO_EMAIL,
            TO_CONSOLE
        };
        public abstract class AlertType
        {
            public abstract void GetAlertType(BreachType breachType);
        }
        public class SendToController : AlertType
        {
            public override void GetAlertType(BreachType breachType)
            {
                AlertTargetTypes.SendToController(breachType);
            }
        }

        public class SendToEmail : AlertType
        {
            public override void GetAlertType(BreachType breachType)
            {
                AlertTargetTypes.SendToEmail(breachType);
            }
        }

        public class SentToConsole : AlertType
        {
            public override void GetAlertType(BreachType breachType)
            {
                AlertTargetTypes.SendToConsole(breachType);
            }
        }

        //For Testing
        public class FakeSentToController : AlertType
        {
            public static bool IsFakeSentToControllerInvoked = false;
            public override void GetAlertType(BreachType breachType)
            {
                IsFakeSentToControllerInvoked = true;
            }
        }
        public class FakeSentToEmail : AlertType
        {
            public static bool IsFakeSentToEmailInvoked = false;
            public override void GetAlertType(BreachType breachType)
            {
                IsFakeSentToEmailInvoked = true;
            }
        }
        public class FakeSentToConsole : AlertType
        {
            public static bool IsFakeSentToConsoleInvoked = false;
            public override void GetAlertType(BreachType breachType)
            {
                IsFakeSentToConsoleInvoked = true;
            }
        }
        public class AlertFactory
        {
            private Dictionary<AlertTarget, Func<AlertType>> _alertTypeMapper;

            public AlertFactory()
            {
                _alertTypeMapper = new Dictionary<AlertTarget, Func<AlertType>>();
                _alertTypeMapper.Add(AlertTarget.TO_CONTROLLER, () => { return new SendToController(); });
                _alertTypeMapper.Add(AlertTarget.TO_EMAIL, () => { return new SendToEmail(); });
                _alertTypeMapper.Add(AlertTarget.TO_CONSOLE, () => { return new SentToConsole(); });
            }

            public AlertType GetAlertBasedOnTargetType(AlertTarget aterType)
            {
                return _alertTypeMapper[aterType]();
            }
        }
    }
}
