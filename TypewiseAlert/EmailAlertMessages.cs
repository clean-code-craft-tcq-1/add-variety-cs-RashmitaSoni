using System;
using static TypewiseAlert.BreachTypeAlert;
using static TypewiseAlert.CoolingTypeAlert;

namespace TypewiseAlert
{
    public interface IInitializeEmailContent
    {
        void GetEmailContent(string Recepient, BreachType BreachType);
    }

    class MailLowBreachTypeInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }

    class MailHighBreachTypeInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }

    class MailNormalStateInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            SetEmailMessagesForBreachType.DisplayEmailContent(Recepient, BreachType);
        }
    }
}
