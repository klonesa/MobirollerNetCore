using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Abstract
{
    public interface IEventItDal:IEntityRepository<EventIt>
    {
        List<EventItDto> GetAllDetails();
        EventItDto GetByEventId(int eventId);
    }
}
