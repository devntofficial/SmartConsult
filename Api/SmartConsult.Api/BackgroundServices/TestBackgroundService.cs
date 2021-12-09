using AutoMapper;
using Microsoft.Extensions.Hosting;
using SmartConsult.Services.SqlServer.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartConsult.Api.BackgroundServices
{
    //thread
    public class TestBackgroundService : BackgroundService
    {
        //private readonly IMapper mapper;
        //private readonly SmartConsultDbContext db;

        public TestBackgroundService(/*IMapper mapper, SmartConsultDbContext db*/)
        {
            //this.mapper = mapper;
            //this.db = db;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //implement logic
            while(!stoppingToken.IsCancellationRequested)
            {
                //forever, lifetime api
                await Task.Delay(3000);

                //if today is friday
                //new years eve

                //scheduled events
                //scheduler
                //libraries -> Quartz.NET

                //health
                //ping database
                Console.WriteLine("My Background Service");
            }
        }
    }
}
