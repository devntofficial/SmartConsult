using SmartConsult.Data.Requests;
using SmartConsult.Services.SqlServer.Contexts;
using System;

namespace SmartConsult.Services.SqlServer
{
    public class DoctorService : IDoctorService
    {
        private readonly IDemoDependency demo;
        private readonly SmartConsultDbContext db;

        public DoctorService(IDemoDependency demo, SmartConsultDbContext db)
        {
            this.demo = demo;
            this.db = db;
        }

        public Guid CreateDoctor(CreateDoctorRequestData data)
        {
            //call sql database and store
            //return id

            Console.WriteLine("Demo object id in service: " + demo.getId());
            return Guid.NewGuid();
        }
    }
}
