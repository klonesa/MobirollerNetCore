using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.DTOs
{
    public class EventsTrDetails:IDto
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="This is required !")]
        public string dc_Zaman { get; set; }

        [Required(ErrorMessage = "This is required !")]
        public string dc_Kategori { get; set; }

        [Required(ErrorMessage = "This is required !")]
        public string dc_Olay { get; set; }
    }
}
