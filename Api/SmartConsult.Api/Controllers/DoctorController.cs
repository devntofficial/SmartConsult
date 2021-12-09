using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly IValidator<DoctorProfileData> validator;
        private readonly IDoctorService doctorService;
        private readonly IFileService fileService;
        private readonly IEmailService emailService;
        private readonly ISmsService smsService;

        public DoctorController(IMediator mediator, IValidator<DoctorProfileData> validator, IDoctorService doctorService,
            IFileService fileService, IEmailService emailService, ISmsService smsService)
        {
            this.mediator = mediator;
            this.validator = validator;
            this.doctorService = doctorService;
            this.fileService = fileService;
            this.emailService = emailService;
            this.smsService = smsService;
        }

        [HttpPost("/api/doctor/without/mediator")]
        public async Task<IActionResult> CreateDoctorProfile([FromForm] DoctorProfileData data, CancellationToken token = default)//files
        {
            ////validate
            var validation = await validator.ValidateAsync(data);
            if (validation.Errors.Any())
            {
                return BadRequest(validation.Errors);
            }

            ////save to database
            var id = await doctorService.CreateProfileAsync(data, token);
            if (id == System.Guid.Empty)
            {
                return BadRequest("Unable to save data to database");
            }

            ////file upload
            var fileUpload = fileService.UploadFiles(id, data.Files);
            if (!fileUpload)//failed
            {
                await doctorService.DeleteProfileAsync(id, token);
                return BadRequest("Unable to save files");
            }

            ////send email
            var emailUpload = emailService.SendEmail(id, data.EmailId, "Some text");
            if (!emailUpload)//failed
            {
                fileService.DeleteFiles(id, data.Files);
                await doctorService.DeleteProfileAsync(id, token);
                return BadRequest("Unable to send email");
            }

            ////send sms
            var smsUpload = smsService.SendSMS(id, data.MobileNo, "Some text");
            if (!smsUpload)//failed
            {
                emailService.RollbackEmailIfPossible(id, data.EmailId, "Some text");
                fileService.DeleteFiles(id, data.Files);
                await doctorService.DeleteProfileAsync(id, token);
                return BadRequest("Unable to send email");
            }
            //
            ///
            //
            return Ok();
        }

        [HttpPost("/api/doctor/with/mediator")]
        public async Task<IActionResult> CreateDoctorProfileWithMediator([FromForm] DoctorProfileData data, CancellationToken token = default)//files
        {
            var output = await mediator.Send(data, token);
            return Ok();
        }
    }
}
