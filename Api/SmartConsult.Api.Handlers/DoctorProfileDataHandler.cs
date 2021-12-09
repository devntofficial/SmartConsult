using FluentValidation;
using MediatR;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Responses;
using SmartConsult.Data.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Handlers
{
    public class DoctorProfileDataHandler : IRequestHandler<DoctorProfileData, DoctorProfileDataResponse>
    {
        private readonly IValidator<DoctorProfileData> validator;
        private readonly IDoctorService service;
        private readonly IMediator mediator;

        public DoctorProfileDataHandler(IValidator<DoctorProfileData> validator, IDoctorService service, IMediator mediator)
        {
            this.validator = validator;
            this.service = service;
            this.mediator = mediator;
        }

        public async Task<DoctorProfileDataResponse> Handle(DoctorProfileData request, CancellationToken cancellationToken)
        {
            //valid
            //saved
            var output = await validator.ValidateAsync(request, cancellationToken);
            if (output.IsValid)
            {
                var id = await service.CreateProfileAsync(request, cancellationToken);//sql

                if (id == System.Guid.Empty)
                {
                    Console.WriteLine("Unable to save data to database");
                    return null;
                }

                //file
                var fileUploadOutput = await mediator.Send(new FileRequestData //irequesthandler<FileRequestData, response>
                {
                    ProfileId = id,
                    MobileNo = request.MobileNo,
                    Email = request.EmailId,
                    Files = request.Files
                });


                if(!fileUploadOutput)
                {
                    //rollback
                    await service.DeleteProfileAsync(id, cancellationToken);
                    return null;
                }

                return new DoctorProfileDataResponse
                {
                    Id = id
                };
            }
            return null;
        }
    }
}
