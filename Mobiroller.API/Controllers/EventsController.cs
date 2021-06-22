using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobiroller.Business.Abstract;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.API.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("ImportTurkishJson")]
        public IActionResult ImportTurkishJson(List<JsonPackage> jsonString)
        {
            return Ok(_eventService.ImportTurkishJson(jsonString));
        }

        [HttpPost("ImportItalianJson")]
        public IActionResult ImportItalianJson(List<JsonPackageIt> jsonString)
        {
            return Ok(_eventService.ImportItalianJson(jsonString));
        }

        [HttpGet("GetAllEventDetails")]
        public IActionResult GetAllEventDetails()
        {
            var result = _eventService.GetAllEventDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
