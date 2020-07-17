using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagerSystem.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _authService;
        IHttpContextAccessor _httpContextAccessor;
        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var loginCompany = _authService.LoginCompany(loginViewModel.CompanyName, loginViewModel.Password);
            if (loginCompany)
            {
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
