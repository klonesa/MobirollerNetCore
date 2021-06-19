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
    public class EfEventTrDal : EfEntityRepository<EventTr, MobirollerContext>, IEventTrDal
    {
        public List<EventTrDto> GetAllDetails()
        {
            using (var context = new MobirollerContext())
            {
                var result = from tr in context.EventsTr
                             select new EventTrDto
                             {
                                 Id = tr.Id,
                                 Tarih = tr.Time,
                                 Kategori = tr.Category,
                                 Olay = tr.Event
                             };
                return result.ToList();
            }
        }

        public EventTrDto GetByEventId(int eventId)
        {
            using (var context = new MobirollerContext())
            {
                var result = from tr in context.EventsTr.Where(x => x.Id == eventId)
                             select new EventTrDto
                             {
                                 Id = tr.Id,
                                 Tarih = tr.Time,
                                 Kategori = tr.Category,
                                 Olay = tr.Event
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
