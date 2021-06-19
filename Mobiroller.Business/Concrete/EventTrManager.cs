using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Concrete
{
    public class EventTrManager : IEventTrService
    {
        private readonly IEventTrDal _eventTrDal;

        public EventTrManager(IEventTrDal eventsTrDal)
        {
            _eventTrDal = eventsTrDal;
        }

        public IDataResult<List<EventTr>> GetAll()
        {
            var result = _eventTrDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<EventTr>>(result, MessagesTR.Listed);
            }
            return new ErrorDataResult<List<EventTr>>(MessagesTR.Error);
        }

        public IDataResult<EventTr> GetById(int eventId)
        {
            var result = _eventTrDal.GetById(eventId);
            if (result != null)
            {
                return new SuccessDataResult<EventTr>(result, MessagesTR.GetById);
            }
            return new ErrorDataResult<EventTr>(MessagesTR.Error);
        }

        public IResult Add(EventTr entity)
        {
            _eventTrDal.Add(entity);
            return new SuccessResult(MessagesTR.Added);
        }

        public IResult Update(EventTr entity)
        {
            _eventTrDal.Update(entity);
            return new SuccessResult(MessagesTR.Updated);
        }

        public IResult Delete(EventTr entity)
        {
            _eventTrDal.Delete(entity);
            return new SuccessResult(MessagesTR.Deleted);
        }
    }
}
