using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Entities;

namespace Mobiroller.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int LanguageId { get; set; }
    }
}
