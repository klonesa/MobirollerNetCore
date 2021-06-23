using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobiroller.Core.Data.EfCore;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.Concrete;
using Mobiroller.Entities.DTOs;

namespace Mobiroller.Data.Concrete.EfCore
{
    public class EfEventDal : EfEntityRepository<EventLog, MobirollerContext>, IEventDal
    {
        public List<EventDetail> GetAllEventDetails()
        {
            using (var context = new MobirollerContext())
            {
                var result = from e in context.EventLog
                             join c in context.Category on e.CategoryId equals c.CategoryId
                             select new EventDetail
                             {
                                 EventId = e.EventId,
                                 EventName = e.EventName,
                                 EventDate = e.EventDate,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }

        public List<EventDetail> GetAllEventDetailsByCategoryId(int categoryId)
        {
            using (var context = new MobirollerContext())
            {
                var result = from e in context.EventLog.Where(x => x.CategoryId == categoryId)
                             join c in context.Category on e.CategoryId equals c.CategoryId
                             select new EventDetail
                             {
                                 EventId = e.EventId,
                                 EventName = e.EventName,
                                 EventDate = e.EventDate,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }

        public List<EventDetail> GetAllEventDetailsByYear(int year)
        {
            using (var context = new MobirollerContext())
            {
                var result = from e in context.EventLog.Where(x => x.EventDate.Year == year)
                             join c in context.Category on e.CategoryId equals c.CategoryId
                             select new EventDetail
                             {
                                 EventId = e.EventId,
                                 EventName = e.EventName,
                                 EventDate = e.EventDate,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }

        public EventDetail GetByEventId(int eventId)
        {
            using (var context = new MobirollerContext())
            {
                var result = from e in context.EventLog.Where(x => x.EventId == eventId)
                             join c in context.Category on e.CategoryId equals c.CategoryId
                             select new EventDetail
                             {
                                 EventId = e.EventId,
                                 EventName = e.EventName,
                                 EventDate = e.EventDate,
                                 CategoryName = c.CategoryName
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
