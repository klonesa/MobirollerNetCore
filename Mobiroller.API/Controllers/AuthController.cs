using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mobiroller.Business.Abstract;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.API.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromForm]User entity)
        {
            var result = _userService.Create(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromForm] UserLogin entity)
        {
            var result = _userService.Login(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
