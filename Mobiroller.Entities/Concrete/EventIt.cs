using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.Concrete
{
    public class EventIt : IEntity
    {
        [Column("ID")]
        public int Id { get; set; }
        
        [Column("dc_Orario")]
        public string Time { get; set; }
       
        [Column("dc_Categoria")]
        public string Category { get; set; }
        
        [Column("dc_Evento")]
        public string Event { get; set; }

    }
}
