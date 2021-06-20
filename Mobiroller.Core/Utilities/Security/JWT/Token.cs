using System;
using System.Collections.Generic;
using System.Text;

namespace Mobiroller.Core.Utilities.Security.JWT
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
