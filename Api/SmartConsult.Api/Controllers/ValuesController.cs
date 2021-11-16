﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SmartConsult.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet("/api/test")]
        public IActionResult GetConfig()
        {
            var myCustomConfig = new MyCustomConfig();
            configuration.Bind("testConfig2", myCustomConfig);
            return Ok(myCustomConfig);
        }

    }
}