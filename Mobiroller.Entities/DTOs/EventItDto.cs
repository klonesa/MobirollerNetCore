using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.DTOs
{
    public class EventItDto:IDto
    {
        public int Id { get; set; }
        public string Orario { get; set; }
        public string Categoria { get; set; }
        public string Evento { get; set; }
    }
}
