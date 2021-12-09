using System;

namespace SmartConsult.Data.Services
{
    public interface IEmailService
    {
        bool SendEmail(Guid id, string email, string text);
        void RollbackEmailIfPossible(Guid id, string email, string text);
    }
}
