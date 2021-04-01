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
            Console.WriteLine("To: {}\n", Recepient);
            Console.WriteLine("Hi, the temperature is too low\n");
        }
    }

    class MailHighBreachTypeInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            Console.WriteLine("To: {}\n", Recepient);
            Console.WriteLine("Hi, the temperature is too high\n");
        }
    }

    class MailNormalStateInfo : IInitializeEmailContent
    {
        public void GetEmailContent(string Recepient, BreachType BreachType)
        {
            Console.WriteLine("To: {}\n", Recepient);
            Console.WriteLine("Hi, the temperature is in normal state\n");
        }
    }
}