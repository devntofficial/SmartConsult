using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartConsult.Services.SqlServer.Entities;

namespace SmartConsult.Services.SqlServer.Configurations
{
    public class DoctorProfileEntityConfiguration : IEntityTypeConfiguration<DoctorProfileEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorProfileEntity> builder)
        {
            builder.ToTable("DoctorProfiles");
            builder.HasKey(x => x.ProfileId);

            builder.Property(x => x.ProfileId).ValueGeneratedOnAdd().HasColumnName("Id");
            builder.Property(x => x.FullName).HasColumnType("varchar(50)").IsRequired();


        }
    }
}
