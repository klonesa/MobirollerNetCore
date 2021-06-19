using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Abstract
{
    public interface IEventTrDal:IEntityRepository<EventTr>
    {
        List<EventTrDto> GetAllDetails();
        EventTrDto GetByEventId(int eventId);
    }
}
