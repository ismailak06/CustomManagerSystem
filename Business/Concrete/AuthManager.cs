using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNetCore.Authentication;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ICompanyService _companyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthManager(ICompanyService companyService, IHttpContextAccessor httpContextAccessor)
        {
            _companyService = companyService;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool LoginCompany(string name, string password)
        {
            var company = _companyService.Get(m => m.Name == name && m.Password == password);
            if (company == null)
            {
                return false;
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("CompanyId", company.Id.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            _httpContextAccessor.HttpContext.SignInAsync(scheme: "PanelSecurityScheme", principal: principal);

            return true;
        }

    }
}
