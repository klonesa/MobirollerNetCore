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
        List<EventDetail> GetAllEventDetailsByEventName(string eventName);
        List<EventDetail> GetAllEventDetailsByCategoryId(int categoryId);
        List<EventDetail> GetAllEventDetailsByYear(int year);
        EventDetail GetByEventId(int eventId);
    }
}
