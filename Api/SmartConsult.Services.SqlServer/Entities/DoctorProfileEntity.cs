using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartConsult.Services.SqlServer.Entities
{
    //[Table("DoctorProfiles")]
    public class DoctorProfileEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }

        [Required]
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Speciality { get; set; }

    }
}
