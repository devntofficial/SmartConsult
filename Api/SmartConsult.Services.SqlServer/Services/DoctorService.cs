using Microsoft.EntityFrameworkCore;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using SmartConsult.Services.SqlServer.Contexts;
using SmartConsult.Services.SqlServer.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Services.SqlServer
{
    public class DoctorService : IDoctorService
    {
        private readonly SmartConsultDbContext db;

        public DoctorService(SmartConsultDbContext db)
        {
            this.db = db;
        }

        public async Task<Guid> CreateProfileAsync(DoctorProfileData data, CancellationToken token = default)
        {
            var profile = new DoctorProfileEntity
            {
                Address = data.Address,
                DateOfBirth = data.DateOfBirth,
                EmailId = data.EmailId,
                FullName = data.FullName,
                MobileNo = data.MobileNo,
                Speciality = data.Speciality,
                Timestamp = DateTime.UtcNow,
            };

            db.DoctorProfiles.Add(profile);
            await db.SaveChangesAsync(token);

            return profile.ProfileId;
        }

        public async Task<DoctorProfileData> GetProfileAsync(string doctorId, CancellationToken token)
        {
            Guid.TryParse(doctorId, out var guid);
            if(guid.Equals(Guid.Empty))
            {
                return null;
            }

            var profile = await db.DoctorProfiles.SingleOrDefaultAsync(x => x.ProfileId == guid, token);

            if(profile == null)
            {
                return null;
            }

            var data = new DoctorProfileData
            {
                Address = profile.Address,
                DateOfBirth = profile.DateOfBirth,
                EmailId = profile.EmailId,
                FullName = profile.FullName,
                MobileNo = profile.MobileNo,
                Speciality = profile.Speciality
            };
            return data;
        }
    }
}
