using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Abstract
{
    public interface IEventTrService
    {
        IDataResult<List<EventTr>> GetAll();
        IDataResult<EventTr> GetById(int eventId);
        IResult Add(EventTr entity);
        IResult Update(EventTr entity);
        IResult Delete(EventTr entity);
    }
}
