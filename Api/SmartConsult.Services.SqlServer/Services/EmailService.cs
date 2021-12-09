using SmartConsult.Data.Services;
using System;

namespace SmartConsult.Services.SqlServer.Services
{
    public class EmailService : IEmailService
    {
        public void RollbackEmailIfPossible(Guid id, string email, string text)
        {
            //in case of SMS failure, if the email was not sent by background service yet
            //then delete that row in database
            Console.WriteLine($"For profile {id}, Email deleted {email} with message: {text}");
        }

        public bool SendEmail(Guid id, string email, string text)
        {
            if (false)
            {
                //assume that email service is first saving email data to sql database
                //and using background service to send emails
                Console.WriteLine($"For profile {id}, Email sent successfully to {email} with message: {text}");
                return true;
            }
            return false;
        }
    }
}
