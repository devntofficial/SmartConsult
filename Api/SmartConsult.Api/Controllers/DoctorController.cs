using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartConsult.Data.Requests;
using SmartConsult.Services;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private IDoctorService service;//transient
        private readonly IDemoDependency demo;

        public DoctorController(IDoctorService abc, IDemoDependency demo)
        {
            service = abc;
            this.demo = demo;
        }


        [HttpPost("/api/doctor")]
        public IActionResult CreateDoctor(CreateDoctorRequestData data, [FromServices] IValidator<CreateDoctorRequestData> validator)
        {
            var output = validator.Validate(data);
            if (output.IsValid)
            {
                var id = service.CreateDoctor(data);
                return Ok(id);
            }
            return BadRequest();

        }
    }
}
