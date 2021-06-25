using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mobiroller.Business.Abstract;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Security.JWT;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.API.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Register([FromForm] User entity)
        {
            var result = _userService.Create(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<Token> Login([FromForm] UserLogin userLogin)
        {
            var context = new MobirollerContext();
            User user = await context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await context.SaveChangesAsync();

                return token;
            }
            return null;
        }


    }
}
