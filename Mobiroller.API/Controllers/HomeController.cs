using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Mobiroller.Business.Abstract;

namespace Mobiroller.API.Controllers
{
    [Route("{culture:culture}/api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IEventTrService _eventsTrService;
        public HomeController(IStringLocalizer<HomeController> localizer, IEventTrService eventsTrService)
        {
            this._localizer = localizer;
            _eventsTrService = eventsTrService;
        }

        public string Get()
        {
            return _localizer["Home"];
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _eventsTrService.GetAll();
            if ( result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
