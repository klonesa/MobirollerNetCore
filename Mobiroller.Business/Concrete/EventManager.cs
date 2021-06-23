using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Core.Aspect.Autofac.Caching;
using Mobiroller.Core.Helpers;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Enum;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;
using Newtonsoft.Json;

namespace Mobiroller.Business.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _eventDal;
        private readonly ICategoryDal _categoryDal;

        public EventManager(IEventDal eventDal, ICategoryDal categoryDal)
        {
            _eventDal = eventDal;
            _categoryDal = categoryDal;
        }

        public IResult ImportTurkishJson(List<JsonPackage> jsonString)
        {
            foreach (var jsonPackage in jsonString)
            {
                EventLog entity = new EventLog();
                entity.EventDate = JsonParseHelper.ParseEventDate(jsonPackage.dc_Zaman, jsonPackage.dc_Olay);
                entity.EventName = jsonPackage.dc_Olay;
                entity.LanguagesId = Languages.Turkish.GetHashCode();
                entity.CategoryId = _categoryDal.GetCategoryIdByName(jsonPackage.dc_Kategori);
                entity.EventId = jsonPackage.Id;
                _eventDal.Add(entity);
            }
            return new SuccessResult(Messages.Added);
        }

        public IResult ImportItalianJson(List<JsonPackageIt> jsonString)
        {
            foreach (var jsonPackageIt in jsonString)
            {
                EventLog entity=new EventLog();
                entity.EventDate = JsonParseHelper.ParseEventDate(jsonPackageIt.dc_Orario, jsonPackageIt.dc_Evento);
                entity.EventName = jsonPackageIt.dc_Evento;
                entity.LanguagesId = Languages.Italian.GetHashCode();
                entity.CategoryId = _categoryDal.GetCategoryIdByNameFromItalian(jsonPackageIt.dc_Categoria);
                entity.EventId = jsonPackageIt.Id;
                _eventDal.Add(entity);
            }
            return new SuccessResult(Messages.Added);
        }

        [CacheAspect]
        public IDataResult<List<EventDetail>> GetAllEventDetails()
        {
            var result = _eventDal.GetAllEventDetails();
            if (result!=null)
            {
                return new SuccessDataResult<List<EventDetail>>(result,Messages.Listed);
            }
            return new ErrorDataResult<List<EventDetail>>(Messages.Error);
        }

        public IDataResult<List<EventDetail>> GetAllEventDetailsCategoryId(int categoryId)
        {
            var result = _eventDal.GetAllEventDetailsByCategoryId(categoryId);
            if (result != null)
            {
                return new SuccessDataResult<List<EventDetail>>(result,Messages.GetById);
            }
            return new ErrorDataResult<List<EventDetail>>(Messages.Error);
        }

        public IDataResult<List<EventDetail>> GetAllEventDetailsByYear(int year)
        {
            var result = _eventDal.GetAllEventDetailsByYear(year);
            if (result!=null)
            {
                return new SuccessDataResult<List<EventDetail>>(result, Messages.Succeed);
            }
            return new SuccessDataResult<List<EventDetail>>(Messages.Error);
        }

        public IDataResult<EventDetail> GetByEventId(int eventId)
        {
            var result = _eventDal.GetByEventId(eventId);
            if (result!=null)
            {
                return new SuccessDataResult<EventDetail>(result,Messages.GetById);
            }
            return new ErrorDataResult<EventDetail>(Messages.Error);
        }
    }
}
