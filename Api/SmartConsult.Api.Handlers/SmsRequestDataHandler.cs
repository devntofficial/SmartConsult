using MediatR;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Handlers
{
    public class SmsRequestDataHandler : IRequestHandler<SmsRequestData, bool>
    {
        private readonly ISmsService service;
        private readonly IMediator mediator;

        public SmsRequestDataHandler(ISmsService service, IMediator mediator)
        {
            this.service = service;
            this.mediator = mediator;
        }

        public async Task<bool> Handle(SmsRequestData request, CancellationToken cancellationToken)
        {
            var output = service.SendSMS(request.ProfileId, request.MobileNo, request.Message);
            return output;
        }
    }
}
