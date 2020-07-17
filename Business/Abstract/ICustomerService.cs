using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Customer GetById(int id);
        IList<Customer> GetListByCompanyId(int companyId);
        bool Add(Customer customer);
    }
}
