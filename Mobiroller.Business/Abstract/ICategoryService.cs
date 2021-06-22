using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Abstract
{
    public interface ICategoryService
    {
        public int GetCategoryIdByName(string categoryName);
        IDataResult<List<Category>> GetAllCategories();
    }
}
