using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Abstract
{
    public interface IUserService
    {
        IResult Create(User entity);
        IResult Login (UserLogin entity);
    }
}
