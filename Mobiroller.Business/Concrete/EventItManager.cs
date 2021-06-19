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
    public class EventItManager:IEventItService
    {
        private readonly IEventItDal _eventItDal;

        public EventItManager(IEventItDal eventItDal)
        {
            _eventItDal = eventItDal;
        }

        public IDataResult<List<EventItDto>> GetAllDetails()
        {
            var result = _eventItDal.GetAllDetails();
            if (result!=null)
            {
                return new SuccessDataResult<List<EventItDto>>(result,MessagesIt.Listed);
            }
            return new ErrorDataResult<List<EventItDto>>(MessagesIt.Error);
        }

        public IDataResult<EventItDto> GetByEventId(int eventId)
        {
            var result = _eventItDal.GetByEventId(eventId);
            if (result!=null)
            {
                return new SuccessDataResult<EventItDto>(result,MessagesIt.GetById);
            }
            return new ErrorDataResult<EventItDto>(MessagesIt.Error);
        }

        public IResult Add(EventIt entity)
        {
            _eventItDal.Add(entity);
            return new SuccessResult(MessagesIt.Added);
        }

        public IResult Update(EventIt entity)
        {
            _eventItDal.Update(entity);
            return new SuccessResult(MessagesIt.Updated);
        }

        public IResult Delete(EventIt entity)
        {
            _eventItDal.Delete(entity);
            return new SuccessResult(MessagesIt.Deleted);
        }
    }
}
