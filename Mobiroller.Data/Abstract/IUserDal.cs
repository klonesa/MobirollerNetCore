using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Security.JWT;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Token Login(UserLogin userLogin);
    }
}
