using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.DTOs
{
    public class EventTrDto:IDto
    {
        public int Id{ get; set; }
        public string Tarih { get; set; }
        public string Kategori { get; set; }
        public string Olay { get; set; }
    }
}
