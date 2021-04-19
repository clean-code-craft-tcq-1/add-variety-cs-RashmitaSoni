using System;
using System.Collections.Generic;
using static TypewiseAlert.BreachTypeAlert;

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
        public interface IAlertType
        {
             void CallAlertTartgetType(BreachType breachType);
        }
        public class SendToController : IAlertType
        {
            public void CallAlertTartgetType(BreachType breachType)
            {
                AlertTargetTypes.SendToController(breachType);
            }
        }

        public class SendToEmail : IAlertType
        {
            public void CallAlertTartgetType(BreachType breachType)
            {
                AlertTargetTypes.SendToEmail(breachType);
            }
        }

        public class SentToConsole : IAlertType
        {
            public void CallAlertTartgetType(BreachType breachType)
            {
                AlertTargetTypes.SendToConsole(breachType);
            }
        }

        //For Testing
        public class FakeSentToController : IAlertType
        {
            public static bool IsFakeSentToControllerInvoked = false;
            public void CallAlertTartgetType(BreachType breachType)
            {
                IsFakeSentToControllerInvoked = true;
            }
        }
        public class FakeSentToEmail : IAlertType
        {
            public static bool IsFakeSentToEmailInvoked = false;
            public void CallAlertTartgetType(BreachType breachType)
            {
                IsFakeSentToEmailInvoked = true;
            }
        }
        public class FakeSentToConsole : IAlertType
        {
            public static bool IsFakeSentToConsoleInvoked = false;
            public void CallAlertTartgetType(BreachType breachType)
            {
                IsFakeSentToConsoleInvoked = true;
            }
        }
        public class AlertFactory
        {
            private Dictionary<AlertTarget, Func<IAlertType>> _alertTypeMapper;

            public AlertFactory()
            {
                _alertTypeMapper = new Dictionary<AlertTarget, Func<IAlertType>>();
                _alertTypeMapper.Add(AlertTarget.TO_CONTROLLER, () => { return new SendToController(); });
                _alertTypeMapper.Add(AlertTarget.TO_EMAIL, () => { return new SendToEmail(); });
                _alertTypeMapper.Add(AlertTarget.TO_CONSOLE, () => { return new SentToConsole(); });
            }

            public IAlertType GetAlertBasedOnTargetType(AlertTarget alertType)
            {
                return _alertTypeMapper[alertType]();
            }
        }
        
    }
}
