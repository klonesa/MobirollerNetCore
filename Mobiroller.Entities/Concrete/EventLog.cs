using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.Concrete
{
    public class EventLog:IEntity
    {
        public int EventId { get; set; }
        public int EventLogId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int LanguagesId { get; set; }
        public int CategoryId { get; set; }
    }
}
