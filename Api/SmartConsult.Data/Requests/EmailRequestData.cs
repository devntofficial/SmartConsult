using MediatR;
using System;

namespace SmartConsult.Data.Requests
{
    public class EmailRequestData : IRequest<bool>
    {
        public Guid ProfileId { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string EmailBody { get; set; }
    }
}
