using SmartConsult.Data.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Data.Services
{
    public interface IDoctorService
    {
        Task<Guid> CreateProfileAsync(DoctorProfileData data, CancellationToken token = default);
        Task<DoctorProfileData> GetProfileAsync(string doctorId, CancellationToken token);
    }
}
