using MediatR;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Handlers
{
    public class FileRequestDataHandler : IRequestHandler<FileRequestData, bool>
    {
        private readonly IFileService service;
        private readonly IMediator mediator;

        public FileRequestDataHandler(IFileService service, IMediator mediator)
        {
            this.service = service;
            this.mediator = mediator;
        }

        public async Task<bool> Handle(FileRequestData request, CancellationToken cancellationToken)
        {

            //changes
            var output = service.UploadFiles(request.ProfileId , request.Files);
            if (output)
            {
                var emailOutput = await mediator.Send(new EmailRequestData 
                {
                    ProfileId = request.ProfileId,
                    MobileNo = request.MobileNo,
                    EmailId = request.Email,
                    EmailBody = "Some email with mediator"
                });

                //rolled
                if (!emailOutput)
                {
                    service.DeleteFiles(request.ProfileId, request.Files);
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
