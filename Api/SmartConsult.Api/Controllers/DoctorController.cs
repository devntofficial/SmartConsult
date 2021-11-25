using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartConsult.Data.Requests;
using SmartConsult.Services;
using SmartConsult.Services.SqlServer.Contexts;
using SmartConsult.Services.SqlServer.Entities;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private IDoctorService service;//transient
        private readonly IDemoDependency demo;
        private readonly SmartConsultDbContext db;

        public DoctorController(IDoctorService abc, IDemoDependency demo, SmartConsultDbContext db)
        {
            service = abc;
            this.demo = demo;
            this.db = db;
        }


        [HttpPost("/api/doctor")]
        public IActionResult CreateDoctor(CreateDoctorRequestData data, [FromServices] IValidator<CreateDoctorRequestData> validator)
        {
            //var output = validator.Validate(data);
            //if (output.IsValid)
            //{
            //    var id = service.CreateDoctor(data);
            //    return Ok(id);
            //}


            var DoctorProfile = new DoctorProfileEntity();
            DoctorProfile.Speciality = "Heart";
            DoctorProfile.FullName = "Nikhil";
            DoctorProfile.DateOfBirth = System.DateTime.UtcNow;


            db.DoctorProfiles.Add(DoctorProfile);
            db.SaveChanges();

            return Ok();

        }
    }
}
