using System;
using System.Collections.Generic;
using System.Text;

namespace Mobiroller.Business.Abstract
{
    public interface ICategoryService
    {
        public int GetCategoryIdByName(string categoryName);
    }
}
