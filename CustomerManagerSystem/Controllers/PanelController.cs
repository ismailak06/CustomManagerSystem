using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete.ViewModels.Panel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Extensions;
namespace CustomerManagerSystem.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICustomerService _customerService;

        public PanelController(ICompanyService companyService, ICustomerService customerService)
        {
            _companyService = companyService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            PanelIndexViewModel model = new PanelIndexViewModel();
            var companyId = User.Identity.CompanyId();
            model.Company = _companyService.GetById(companyId);
            model.Customers = _customerService.GetListByCompanyId(companyId);
            TempData["CompanyId"] = companyId.ToString();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(PanelIndexViewModel model)
        {
            var companyId = User.Identity.CompanyId();
            model.Company = _companyService.GetById(companyId);
            model.Customers = _customerService.GetListByCompanyId(companyId);
            if (string.IsNullOrEmpty(model.Customer.CitizienNumber))
            {
                ModelState.AddModelError("TcError", "T.C. alanı boş geçilemez.");
                return View(model);
            }
            else
            {
                model.Customer.CompanyId = int.Parse(TempData["CompanyId"].ToString());
                _customerService.Add(model.Customer);
               
                return RedirectToAction("Index", model);
            }
        }
    }
}
