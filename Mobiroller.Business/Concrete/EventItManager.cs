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
    public class EventItManager:IEventItService
    {
        private readonly IEventItDal _eventItDal;

        public EventItManager(IEventItDal eventItDal)
        {
            _eventItDal = eventItDal;
        }

        public IDataResult<List<EventIt>> GetAll()
        {
            var result = _eventItDal.GetAll();
            if (result!=null)
            {
                return new SuccessDataResult<List<EventIt>>(result, MessagesIt.Listed);
            }
            return new ErrorDataResult<List<EventIt>>(MessagesIt.Error);
        }

        public IDataResult<EventIt> GetById(int eventId)
        {
            var result = _eventItDal.GetById(eventId);
            if (result!=null)
            {
                return new SuccessDataResult<EventIt>(result, MessagesIt.GetById);
            }
            return new ErrorDataResult<EventIt>(MessagesIt.Error);
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
