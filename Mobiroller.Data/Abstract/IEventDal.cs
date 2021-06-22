using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Abstract
{
    public interface IEventDal:IEntityRepository<EventLog>
    {
        List<EventDetail> GetAllEventDetails();
        List<EventDetail> GetAllEventDetailsByCategoryId(int categoryId);
        EventDetail GetByEventId(int eventId);
    }
}
