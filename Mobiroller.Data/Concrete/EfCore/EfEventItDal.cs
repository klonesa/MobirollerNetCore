using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data.EfCore;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Data.Concrete.EfCore
{
    public class EfEventItDal:EfEntityRepository<EventIt,MobirollerContext>,IEventItDal
    {
    }
}
