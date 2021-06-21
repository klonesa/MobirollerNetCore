using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobiroller.Core.Data.EfCore;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Data.Concrete.EfCore
{
    public class EfEventDal:EfEntityRepository<EventLog,MobirollerContext>,IEventDal
    {
    }
}
