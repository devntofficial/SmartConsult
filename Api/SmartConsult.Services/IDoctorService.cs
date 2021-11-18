using SmartConsult.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartConsult.Services
{
    public  interface IDoctorService
    {
        Guid CreateDoctor(CreateDoctorRequestData data);
    }
}
