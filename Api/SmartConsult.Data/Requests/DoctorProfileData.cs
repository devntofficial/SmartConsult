using FluentValidation;
using System;

namespace SmartConsult.Data.Requests
{
    public class DoctorProfileData
    {
        public string DataFullName { get; set; }
        public string DataEmailId { get; set; }
        public string DataMobileNo { get; set; }
        public string DataAddress { get; set; }
        public string DataDateOfBirth { get; set; }
        public string DataSpecialityName { get; set; }
    }

    public class DoctorRequestValidator : AbstractValidator<DoctorProfileData>
    {
        public DoctorRequestValidator()
        {

        }
    }
}
