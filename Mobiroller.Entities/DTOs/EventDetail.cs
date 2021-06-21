using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.DTOs
{
    public class EventDetail : IDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string CategoryName { get; set; }
    }
}
