using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Mobiroller.Core.Entities.Concrete;

namespace Mobiroller.Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(30);
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
