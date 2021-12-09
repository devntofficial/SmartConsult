using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartConsult.Data.Responses;
using System.Collections.Generic;

namespace SmartConsult.Data.Requests
{
    public class DoctorProfileData : IRequest<DoctorProfileDataResponse>
    {
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Speciality { get; set; }

        public List<IFormFile> Files { get; set; }
    }

    public class DoctorRequestValidator : AbstractValidator<DoctorProfileData>
    {
        public DoctorRequestValidator()
        {

        }
    }
}
