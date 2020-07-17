using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICompanyService _companyService;
        public CustomerManager(ICustomerDal customerDal, ICompanyService companyService)
        {
            _customerDal = customerDal;
            _companyService = companyService;
        }

        public bool Add(Customer customer)
        {
            var selectedCompany = _companyService.GetById(customer.CompanyId);
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Lastname = customer.Lastname,
                CompanyId = customer.CompanyId,
                CitizienNumber = selectedCompany.TcIsrequired == true ? customer.CitizienNumber : null,
                BirthDate = customer.BirthDate
            };


            _customerDal.Add(newCustomer);
            return true;
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public IList<Customer> GetListByCompanyId(int companyId)
        {
            return _customerDal.GetList(m => m.CompanyId == companyId).ToList();
        }
    }
}
