using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.Concrete
{
    public class EventTr:IEntity
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("dc_Zaman")]
        public string Time { get; set; }

        [Column("dc_Kategori")]
        public string Category { get; set; }

        [Column("dc_Olay")]
        public string Event { get; set; }
    }
}
