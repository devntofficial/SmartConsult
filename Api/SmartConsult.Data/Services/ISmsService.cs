using System;

namespace SmartConsult.Data.Services
{
    public interface ISmsService
    {
        bool SendSMS(Guid id, string mobileno, string text);
    }
}
