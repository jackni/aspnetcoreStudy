using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Services;
using NetCoreWebApi.Models;
using NetCoreWebApi.Infrastructure.Filter;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ServiceFilter(typeof(LoggingActionFilterAttribute))]
    public class MatchController : Controller
    {
        private readonly IMathService _mathService;

        public MatchController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpPost]
        [Route("Add")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult Add(CalcuatorModel calcuatorRequest)
        {
            return Ok(_mathService.Add(calcuatorRequest.X, calcuatorRequest.Y));
        }

        [HttpPost, MapToApiVersion("2.0")]
        [Route("Add2")]
        [ApiExplorerSettings(GroupName = "v2")]
        public IActionResult Add2(CalcuatorModel calcuatorRequest)
        {
            return Ok(_mathService.Add(calcuatorRequest.X, calcuatorRequest.Y));
        }
    }
}
