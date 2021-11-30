using AutoMapper;
using SmartConsult.Data.Requests;
using SmartConsult.Services.SqlServer.Entities;
using System;

namespace SmartConsult.Services.SqlServer.Mappers
{
    public class DoctorMapperProfile : Profile
    {
        public DoctorMapperProfile()
        {
            CreateMap<DoctorProfileEntity, DoctorProfileData>();
            CreateMap<DoctorProfileData, DoctorProfileEntity>()//100, 95 are similar, 5
                .ForMember(x => x.EmailId, y => y.MapFrom(z => z.DataEmailId))
                .ForMember(x => x.MobileNo, y => y.MapFrom(z => z.DataMobileNo));

            //CreateMap<DoctorProfileEntity, DoctorProfileData>().ConvertUsing(x => EntityToDataMapper(x));
            //CreateMap<DoctorProfileData, DoctorProfileEntity>().ConvertUsing(x => DataToEntityMapper(x));
        }

        //private DoctorProfileEntity DataToEntityMapper(DoctorProfileData data)
        //{
        //    return new DoctorProfileEntity
        //    {
        //        Address = data.DataAddress,
        //        DateOfBirth = DateTime.Parse(data.DataDateOfBirth),
        //        EmailId = data.DataEmailId,
        //        FullName = data.DataFullName,
        //        MobileNo = data.DataMobileNo,
        //        Speciality = data.DataSpecialityName,
        //        Timestamp = DateTime.UtcNow,
        //    };
        //}

        //private DoctorProfileData EntityToDataMapper(DoctorProfileEntity entity)
        //{
        //    return new DoctorProfileData
        //    {
        //        DataAddress = entity.Address,
        //        DataDateOfBirth = entity.DateOfBirth.ToString(),
        //        DataEmailId = entity.EmailId,
        //        DataFullName = entity.FullName,
        //        DataMobileNo = entity.MobileNo,
        //        DataSpecialityName = entity.Speciality
        //    };
        //}
    }
}
