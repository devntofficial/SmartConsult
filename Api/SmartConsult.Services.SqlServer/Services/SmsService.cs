using SmartConsult.Data.Services;
using System;

namespace SmartConsult.Services.SqlServer.Services
{
    public class SmsService : ISmsService
    {
        public bool SendSMS(Guid id, string mobileno, string text)
        {
            if (true)
            {
                Console.WriteLine($"For profile {id}, SMS sent successfully to {mobileno} with message: {text}");
                return true;
            }
            return false;
        }
    }
}
