using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Mobiroller.Core.Data.EfCore;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Security.JWT;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Concrete.EfCore
{
    public class EfUserDal:EfEntityRepository<User,MobirollerContext>,IUserDal
    {
        private readonly IConfiguration _configuration;

        public EfUserDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserLogin Login(UserLogin userLogin)
        {
            using (var context=new MobirollerContext())
            {
                var result =
                    context.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
                if (result != null)
                {
                    //Token üretiliyor.
                    TokenHandler tokenHandler = new TokenHandler(_configuration);
                    Mobiroller.Core.Utilities.Security.JWT.Token token = tokenHandler.CreateAccessToken(result);

                    //Refresh token Users tablosuna işleniyor.
                    //result.RefreshToken = token.RefreshToken;
                    //result.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                    //return token;
                }
                return null;
            }
        }
    }
}
