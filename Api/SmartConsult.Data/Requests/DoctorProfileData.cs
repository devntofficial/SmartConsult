using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartConsult.Data.Requests
{
    public class DoctorProfileData
    {
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Speciality { get; set; }
    }

    public class DoctorRequestValidator : AbstractValidator<DoctorProfileData>
    {
        public DoctorRequestValidator()
        {
            
        }
    }
}
