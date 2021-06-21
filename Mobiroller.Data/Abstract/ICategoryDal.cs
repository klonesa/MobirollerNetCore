using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Data;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Data.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        int GetCategoryIdByName(string categoryName);
        int GetCategoryIdByNameFromItalian (string categoryName);
    }
}
