using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Extensions.Localization;
using Mobiroller.Business.Abstract;
using Mobiroller.Entities.DTOs;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;
using Mobiroller.Core.Aspect.Autofac.Caching;

namespace Mobiroller.API.Controllers
{
    [Route("api/[controller]")]
    //[Consumes("application/json")]
    [Authorize]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IStringLocalizer<EventsController> _localizer;
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService, IStringLocalizer<EventsController> localizer)
        {
            _eventService = eventService;
            _localizer = localizer;
        }

        [HttpPost("ImportTurkishJson")]
        [CacheRemoveAspect("IEventService.Get")]
        public IActionResult ImportTurkishJson(List<JsonPackage> jsonString)
        {
            return Ok(_eventService.ImportTurkishJson(jsonString));
        }

        [HttpPost("ImportItalianJson")]
        [CacheRemoveAspect("IEventService.Get")]
        public IActionResult ImportItalianJson(List<JsonPackageIt> jsonString)
        {
            return Ok(_eventService.ImportItalianJson(jsonString));
        }

        [AllowAnonymous]
        [CacheAspect]
        [HttpGet("GetAllEventDetails")]
        public IActionResult GetAllEventDetails()
        {
            //CultureInfo.CurrentUICulture = new CultureInfo(HttpContext.Request.Headers["Accept-Language"].ToString());
            var result = _eventService.GetAllEventDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
       
        [AllowAnonymous]
        [HttpGet("GetAllEventDetailsByEventName")]
        public IActionResult GetAllEventDetailsByEventName(string eventName)
        {
            var result = _eventService.GetAllEventDetailsByEventName(eventName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("GetAllEventDetailsByCategoryId")]
        public IActionResult GetAllEventDetailsCategoryId(int categoryId)
        {
            var result = _eventService.GetAllEventDetailsByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("GetAllEventDetailsByYear")]
        public IActionResult GetAllEventDetailsByYear(int year)
        {
            var result = _eventService.GetAllEventDetailsByYear(year);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpGet("GetByEventId")]
        public IActionResult GetByEventId(int eventId)
        {
            var result = _eventService.GetByEventId(eventId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
