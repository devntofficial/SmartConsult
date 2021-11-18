using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartConsult.Data.Requests;
using SmartConsult.Services;
using System;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private IDoctorService service;//transient
        private readonly IDemoDependency demo;
        private readonly IValidator<CreateDoctorRequestData> validator;

        public DoctorController(IDoctorService abc, IDemoDependency demo, IValidator<CreateDoctorRequestData> validator)
        {
            service = abc;
            this.demo = demo;
            this.validator = validator;
        }


        [HttpPost("/api/doctor")]
        public IActionResult CreateDoctor(CreateDoctorRequestData data)
        {
            var output = validator.Validate(data);
            if(output.IsValid)
            {
                var id = service.CreateDoctor(data);
                return Ok(id);
            }
            return BadRequest();
            
        }

        [HttpPut("/api/doctor")]
        public IActionResult UpdateDoctor(CreateDoctorRequestData data)
        {
            var id = service.CreateDoctor(data);
            return Ok(id);
        }

    }
}
