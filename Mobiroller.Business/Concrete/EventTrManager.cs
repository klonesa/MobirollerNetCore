using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Business.Concrete
{
    public class EventTrManager : IEventTrService
    {
        private readonly IEventTrDal _eventTrDal;

        public EventTrManager(IEventTrDal eventsTrDal)
        {
            _eventTrDal = eventsTrDal;
        }

        public IDataResult<List<EventTrDto>> GetAllDetails()
        {
            var result = _eventTrDal.GetAllDetails();
            if (result != null)
            {
                return new SuccessDataResult<List<EventTrDto>>(result, MessagesTR.Listed);
            }
            return new ErrorDataResult<List<EventTrDto>>(MessagesTR.Error);
        }

        public IDataResult<EventTrDto> GetByEventId(int eventId)
        {
            var result = _eventTrDal.GetByEventId(eventId);
            if (result != null)
            {
                return new SuccessDataResult<EventTrDto>(result, MessagesTR.GetById);
            }
            return new ErrorDataResult<EventTrDto>(MessagesTR.Error);
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
