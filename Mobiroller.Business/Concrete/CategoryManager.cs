﻿using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.Concrete;

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

        public IDataResult<List<Category>> GetAllCategories()
        {
            var result = _categoryDal.GetAll();
            if (result!=null)
            {
                return new SuccessDataResult<List<Category>>(result,Messages.Listed);
            }
            return new ErrorDataResult<List<Category>>(Messages.Error);
        }
    }
}
