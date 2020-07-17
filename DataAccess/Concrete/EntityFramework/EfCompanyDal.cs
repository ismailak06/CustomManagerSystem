using DataAccess.Abstract;
using DataAccess.Models;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, CMSDbContext>, ICompanyDal
    {
    }
}
