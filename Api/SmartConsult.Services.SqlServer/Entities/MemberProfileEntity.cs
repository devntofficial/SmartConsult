using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartConsult.Services.SqlServer.Entities
{
    public class MemberProfileEntity
    {
        public int ProfileId { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Speciality { get; set; }

    }
}
