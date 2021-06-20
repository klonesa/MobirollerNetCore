using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.DTOs
{
    public class UserLogin:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
