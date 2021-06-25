using System;
using System.Collections.Generic;
using System.Text;
using Mobiroller.Business.Abstract;
using Mobiroller.Business.Constants;
using Mobiroller.Core.Utilities.Results;
using Mobiroller.Data.Abstract;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Business.Concrete
{
    public class LanguageManager:ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public IDataResult<List<Language>> GetAllLanguages()
        {
            var result = _languageDal.GetAll();
            if (result!=null)
            {
                return new SuccessDataResult<List<Language>>(result, Messages.Listed);
            }

            return new ErrorDataResult<List<Language>>(Messages.Error);
        }

        public IResult Add(Language entity)
        {
            _languageDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Language entity)
        {
            _languageDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Language entity)
        {
            _languageDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
