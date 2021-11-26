using Microsoft.EntityFrameworkCore;
using SmartConsult.Services.SqlServer.Configurations;
using SmartConsult.Services.SqlServer.Entities;

namespace SmartConsult.Services.SqlServer.Contexts
{
    public class SmartConsultDbContext : DbContext
    {
        public SmartConsultDbContext(DbContextOptions<SmartConsultDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MemberProfileEntity>().ToTable("Members").HasKey(x => x.ProfileId);
            builder.Entity<MemberProfileEntity>().Property(x => x.ProfileId).HasColumnName("Id");
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorProfileEntityConfiguration).Assembly);
        }


        public DbSet<DoctorProfileEntity> DoctorProfiles { get; set; }
        public DbSet<MemberProfileEntity> MemberProfiles { get; set; }
    }
}
