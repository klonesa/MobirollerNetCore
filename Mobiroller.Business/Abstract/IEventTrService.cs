using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Abstract
{
    public interface IEventTrService
    {
        IDataResult<List<EventTrDto>> GetAllDetails();
        IDataResult<EventTrDto> GetByEventId(int id);
        IResult Add(EventTr entity);
        IResult Update(EventTr entity);
        IResult Delete(EventTr entity);
    }
}
