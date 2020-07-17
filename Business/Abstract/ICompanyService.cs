using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Company Get(Expression<Func<Company, bool>> filter);
        Company GetById(int id);
    }
}
