using MediatR;
using System;

namespace SmartConsult.Data.Requests
{
    public class SmsRequestData : IRequest<bool>
    {
        public Guid ProfileId { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
    }
}
