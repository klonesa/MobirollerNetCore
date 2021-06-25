using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Mobiroller.Business.Abstract;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("GetAllLanguages")]
        public IActionResult GetAllLanguages()
        {
            var result = _languageService.GetAllLanguages();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult Add(Language entity)
        {
            var result = _languageService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(Language entity)
        {
            var result = _languageService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Language entity)
        {
            var result = _languageService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
