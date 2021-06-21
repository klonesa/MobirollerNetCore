using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobiroller.Core.Data.EfCore;
using Mobiroller.Core.Helpers;
using Mobiroller.Data.Abstract;
using Mobiroller.Data.Contexts;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Data.Concrete.EfCore
{
    public class EfCategoryDal:EfEntityRepository<Category,MobirollerContext>,ICategoryDal
    {
        public int GetCategoryIdByName(string categoryName)
        {
            using (var context=new MobirollerContext())
            {
                return context.Category.Where(c => c.CategoryName.ToLower().Equals(JsonParseHelper.utf8Converter(categoryName.ToLower()))).FirstOrDefault().CategoryId;
            }
        }

        public int GetCategoryIdByNameFromItalian(string categoryName)
        {
            using (var context=new MobirollerContext())
            {
                return context.Category.FirstOrDefault(c => c.CategoryName.ToLower().Equals(categoryName.ToLower())).CategoryId;
                    
            }
        }
    }
}
