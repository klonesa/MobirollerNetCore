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
    public class EfUserDal : EfEntityRepository<User, MobirollerContext>, IUserDal
    {
        private readonly IConfiguration _configuration;

        public EfUserDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token Login(UserLogin userLogin)
        {
            //using (var context = new MobirollerContext())
            //{
            //    User user = context.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

            //    //Token üretiliyor.
            //    TokenHandler tokenHandler = new TokenHandler(_configuration);
            //    Token token = tokenHandler.CreateAccessToken(user);

            //    //Refresh token Users tablosuna işleniyor.
            //    if (user != null)
            //    {
            //        user.RefreshToken = token.RefreshToken;
            //        user.RefreshTokenEndDate = token.Expiration.AddMinutes(15);
            //    }

            //    context.SaveChanges();
            //    return token;

            //}
            return null;
        }
    }
}
