using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Services;

namespace NetCoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Greeting")]
    public class GreetingController : Controller
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("{name}")]
        public IActionResult SayHello(string name)
        {

            return Ok(_greetingService.SayHelloTo(name));
        }
    }
}