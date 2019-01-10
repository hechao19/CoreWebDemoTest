using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiBase")]
    public class ApiBaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetActionData()
        {
            return this.Ok(new { id = 1, name = "1" });
        }
    }
}