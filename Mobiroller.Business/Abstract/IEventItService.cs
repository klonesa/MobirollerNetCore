using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Abstract
{
    public interface IEventItService
    {
        IDataResult<List<EventIt>> GetAll();
        IDataResult<EventIt> GetById(int eventId);
        IResult Add(EventIt entity);
        IResult Update(EventIt entity);
        IResult Delete(EventIt entity);
    }
}
