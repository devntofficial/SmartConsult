using MediatR;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Handlers
{
    public class EmailRequestDataHandler : IRequestHandler<EmailRequestData, bool>
    {
        private readonly IEmailService service;
        private readonly IMediator mediator;

        public EmailRequestDataHandler(IEmailService service, IMediator mediator)
        {
            this.service = service;
            this.mediator = mediator;
        }

        public async Task<bool> Handle(EmailRequestData request, CancellationToken cancellationToken)
        {
            var output = service.SendEmail(request.ProfileId, request.EmailId, "Some email message");
            if (output)
            {

                //send sms
                var smsSent = await mediator.Send(new SmsRequestData
                {
                    ProfileId = request.ProfileId,
                    Message = "Some sms text",
                    MobileNo = request.MobileNo
                });

                if (smsSent)
                {
                    return true;
                }
                else
                {
                    service.RollbackEmailIfPossible(request.ProfileId, request.EmailId, "Some email message");
                }
            }
            return false;
        }
    }
}
