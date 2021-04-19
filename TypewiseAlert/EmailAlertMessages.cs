using System;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
      public interface IInitializeEmailContent
    {
        void GetEmailContent(string Recepient, BreachType BreachType);
    }

    public class MailLowBreachTypeInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }

    public class MailHighBreachTypeInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }

    public class MailNormalStateInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }
}
