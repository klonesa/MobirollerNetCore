using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        UserLogin Login(UserLogin userLogin);
    }
}
