using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartConsult.Data.Requests;
using SmartConsult.Data.Services;
using SmartConsult.Services.SqlServer.Contexts;
using SmartConsult.Services.SqlServer.Entities;
using SmartConsult.Services.SqlServer.Mappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Services.SqlServer
{
    public class DoctorService : IDoctorService
    {
        private readonly SmartConsultDbContext db;
        private readonly IMapper mapper;

        public DoctorService(SmartConsultDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Guid> CreateProfileAsync(DoctorProfileData data, CancellationToken token = default)
        {
            //var profile = data.MapToEntity();
            var profile = mapper.Map<DoctorProfileEntity>(data);

            db.DoctorProfiles.Add(profile);
            await db.SaveChangesAsync(token);

            return profile.ProfileId;
        }

        public async Task<DoctorProfileData> GetProfileAsync(string doctorId, CancellationToken token)
        {
            Guid.TryParse(doctorId, out var guid);
            if (guid.Equals(Guid.Empty))
            {
                return null;
            }

            var profile = await db.DoctorProfiles.SingleOrDefaultAsync(x => x.ProfileId == guid, token);

            if (profile == null)
            {
                return null;
            }

            //var data = profile.MapToDataObject();
            var data = mapper.Map<DoctorProfileData>(profile);
            return data;
        }
    }
}
