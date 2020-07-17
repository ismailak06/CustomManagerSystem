using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        public readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public Company Get(Expression<Func<Company, bool>> filter)
        {
            return _companyDal.Get(filter);
        }

        public Company GetById(int id)
        {
            return _companyDal.GetById(id);
        }
    }
}
