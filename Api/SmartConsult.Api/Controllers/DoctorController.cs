using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using SmartConsult.Services;
using SmartConsult.Services.SqlServer.Contexts;
using SmartConsult.Services.SqlServer.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;

        public DoctorController(IDoctorService service)
        {
            this.service = service;
        }


        [HttpPost("/api/doctor")]
        public async Task<IActionResult> CreateDoctorProfile(DoctorProfileData data,
            [FromServices] IValidator<DoctorProfileData> validator, CancellationToken token = default)
        {
            var output = await validator.ValidateAsync(data, token);
            if (output.IsValid)
            {
                var id = await service.CreateProfileAsync(data, token);
                return Ok(id);
            }
            return BadRequest();
        }

        [HttpGet("/api/doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorProfile([FromRoute]string doctorId,
            [FromServices] IValidator<DoctorProfileData> validator, CancellationToken token = default)
        {
            if (!string.IsNullOrWhiteSpace(doctorId))
            {
                var profile = await service.GetProfileAsync(doctorId, token);
                return profile == null ? NotFound() : Ok(profile);
            }
            return BadRequest();
        }
    }
}
