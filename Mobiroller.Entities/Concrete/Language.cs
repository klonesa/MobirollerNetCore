using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.Concrete
{
    public class Language:IEntity
    {
        [Key]
        public int LanguagesId { get; set; }
        public string LanguagesName { get; set; }
        public string LanguagesAlias { get; set; }
    }
}
