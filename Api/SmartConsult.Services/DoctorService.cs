using SmartConsult.Data.Requests;
using System;

namespace SmartConsult.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDemoDependency demo;

        public DoctorService(IDemoDependency demo)
        {
            this.demo = demo;
        }

        public Guid CreateDoctor(CreateDoctorRequestData data)
        {
            //map your data to entity - AutoMapper / 
            //call sql database and store entity
            //return id
            Console.WriteLine("Demo object id in service: " + demo.getId());
            return Guid.NewGuid();
        }
    }
}
