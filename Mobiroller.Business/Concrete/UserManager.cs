using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.ValidationRules.FluentValidation;
using Mobiroller.Core.Aspect.Autofac.Validation;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Create(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult("User create successfully !");
        }

        public IDataResult<UserLogin> Login(UserLogin entity)
        {
            var result = _userDal.Login(entity);
            if (result!=null)
            {
                return new SuccessDataResult<UserLogin>(result,"Login successfully !");
            }
            return new ErrorDataResult<UserLogin>("Login failed !");
        }
    }
}
