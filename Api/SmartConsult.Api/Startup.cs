using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartConsult.Data.Requests;
using SmartConsult.Services;
using SmartConsult.Services.SqlServer.Contexts;
using System.Reflection;

namespace SmartConsult.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddTransient<IDemoDependency, DemoDependency>();

            var dataAssembly = Assembly.GetAssembly(typeof(DoctorRequestValidator));
            services.AddValidatorsFromAssemblies(new[] { dataAssembly });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartConsult.Api", Version = "v1" });
            });

            services.AddDbContext<SmartConsultDbContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("SmartConsultDb"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartConsult.Api v1"));
            }

            app.UseHttpsRedirection();



            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
