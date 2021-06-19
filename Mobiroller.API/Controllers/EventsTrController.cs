﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Mobiroller.Business.Abstract;

namespace Mobiroller.API.Controllers
{
    [Route("tr-TR/api/events")]
    [ApiController]
    public class EventsTrController : ControllerBase
    {
        private IStringLocalizer<EventsTrController> _localizer;
        private readonly IEventTrService _eventTrService;

        public EventsTrController(IStringLocalizer<EventsTrController> localizer, IEventTrService eventTrService)
        {
            _localizer = localizer;
            _eventTrService = eventTrService;
        }

        public string Get()
        {
            return _localizer["Event"];
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _eventTrService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetByEventId")]
        public IActionResult GetByEventId(int eventId)
        {
            var result = _eventTrService.GetByEventId(eventId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


    }
}
