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
    [Route("it-IT/api/events")]
    [ApiController]
    public class EventsItController : ControllerBase
    {
        private IStringLocalizer<EventsItController> _localizer;
        private readonly IEventItService _eventItService;

        public EventsItController(IStringLocalizer<EventsItController> localizer, IEventItService eventItService)
        {
            _localizer = localizer;
            _eventItService = eventItService;
        }

        public string Get()
        {
            return _localizer["Event"];
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _eventItService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
