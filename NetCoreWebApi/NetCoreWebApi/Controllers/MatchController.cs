using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Services;
using NetCoreWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private readonly IMathService _mathService;

        public MatchController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpPost( Name ="Add")]
        public IActionResult Add(CalcuatorModel calcuatorRequest)
        {
            return Ok(_mathService.Add(calcuatorRequest.X, calcuatorRequest.Y));
        }
    }
}
