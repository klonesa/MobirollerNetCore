using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;

namespace Mobiroller.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int GetCategoryIdByName(string categoryName)
        {
           return _categoryDal.GetCategoryIdByName(categoryName);
           
        }
    }
}
