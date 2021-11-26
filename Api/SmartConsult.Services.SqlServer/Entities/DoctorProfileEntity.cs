using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartConsult.Services.SqlServer.Entities
{
    public class DoctorProfileEntity
    {
        public Guid ProfileId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Speciality { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
