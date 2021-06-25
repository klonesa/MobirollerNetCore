using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<List<Language>> GetAllLanguages();
        IResult Add(Language entity);
        IResult Update(Language entity);
        IResult Delete(Language entity);
    }
}
