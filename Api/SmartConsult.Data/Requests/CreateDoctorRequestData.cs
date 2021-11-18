using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartConsult.Data.Requests
{
    public class CreateDoctorRequestData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } = 0;
        public DateTime DateOfBirth { get; set; }
        public string Speciality { get; set; }

    }

    public class DoctorRequestValidator : AbstractValidator<CreateDoctorRequestData>
    {
        public DoctorRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Speciality).Must(BeAValidSpecilaity).Must(NotHaveSymbols);
        }

        private bool NotHaveSymbols(string speciality)
        {
            throw new NotImplementedException();
        }

        private bool BeAValidSpecilaity(string speciality)
        {
            //reg
            //
            return Regex.IsMatch(speciality, "");
            
        }
    }
}
