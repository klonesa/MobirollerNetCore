using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Business.ValidationRules.FluentValidation;
using Mobiroller.Core.Aspect.Autofac.Validation;
using Mobiroller.Core.Entities.Concrete;
using Mobiroller.Core.Utilities.Business;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Create(User entity)
        {
            IResult result = BusinessRules.Run(CheckIfUserEmailExists(entity.Email));
            if (result == null)
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserRegistered);
            }

            return result;
        }

        public IResult Login(UserLogin entity)
        {
            var result = _userDal.Login(entity);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.Error);
        }

        private IResult CheckIfUserEmailExists(string email)
        {
            var result = _userDal.GetAll(x => x.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
