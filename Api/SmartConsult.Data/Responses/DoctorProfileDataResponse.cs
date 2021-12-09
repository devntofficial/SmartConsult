using System;

namespace SmartConsult.Data.Responses
{
    public class DoctorProfileDataResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Speciality { get; set; }
    }
}
