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
    public class EfEventItDal:EfEntityRepository<EventIt,MobirollerContext>,IEventItDal
    {
        public List<EventItDto> GetAllDetails()
        {
            using (var context=new MobirollerContext())
            {
                var result = from it in context.EventsIt
                    select new EventItDto
                    {
                        Id = it.Id,
                        Orario = it.Time,
                        Categoria = it.Category,
                        Evento = it.Event
                    };
                return result.ToList();
            }
        }

        public EventItDto GetByEventId(int eventId)
        {
            using (var context=new MobirollerContext())
            {
                var result = from it in context.EventsIt.Where(x => x.Id == eventId)
                    select new EventItDto
                    {
                        Id = it.Id,
                        Orario = it.Time,
                        Categoria = it.Category,
                        Evento = it.Event
                    };
                return result.SingleOrDefault();
            }
        }
    }
}
