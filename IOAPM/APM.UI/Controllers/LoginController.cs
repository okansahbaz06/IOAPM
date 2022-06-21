using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APM.UI.Controllers
{
    public class LoginController : Controller
    {

        readonly ITokenProvider _tokenProvider;
        readonly IEmployeeRepository _employeeRepository;

        public LoginController(ITokenProvider tokenProvider, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LoginUser(UserDto user)
        {
            try
            {
                if (user.EMAIL != null || user.PASSWORD != null)
                {
                    var pass = _tokenProvider.EncryptString(user.PASSWORD);
                    var userToken = _tokenProvider.LoginUser(user.EMAIL.Trim(), pass);

                    if (userToken != null)
                    {
                        HttpContext.Session.SetString("JWToken", userToken);
                        return Json(new { status = true });
                    }
                    else
                        return Json(new { status = false });
                }
                return Json(new { status = false });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

        public IActionResult NotFound404() // Cevap yoksa
        {
            return View();
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

    }
}
