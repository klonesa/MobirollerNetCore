using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Abstract
{
    public interface IEventItService
    {
        IDataResult<List<EventItDto>> GetAllDetails();
        IDataResult<EventItDto> GetByEventId(int eventId);
        IResult Add(EventIt entity);
        IResult Update(EventIt entity);
        IResult Delete(EventIt entity);
    }
}
