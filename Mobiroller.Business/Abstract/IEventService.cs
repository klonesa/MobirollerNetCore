using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Abstract
{
    public interface IEventService
    {
        IResult ImportTurkishJson(List<JsonPackage> jsonString);
        IResult ImportItalianJson(List<JsonPackageIt> jsonString);
    }
}
