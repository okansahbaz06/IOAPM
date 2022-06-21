using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN, Roles.NORMAL)]
    public class DashboardController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly ITokenProvider _tokenProvider;

        public DashboardController(IEmployeeRepository employeeRepository, ITokenProvider tokenProvider)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
        }

        public IActionResult Index()
        {
            UserDto loggedUser = new UserDto();
            var userDto = new EmployeeDto();
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIdentity.Claims;

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    foreach (var claim in userClaims)
                    {
                        var cType = claim.Type;
                        var cValue = claim.Value;

                        switch (cType)
                        {
                            case "ID":
                                loggedUser.ID = cValue;
                                break;
                        }
                    }
                    userDto = _employeeRepository.Get(Convert.ToInt16(loggedUser.ID));
                }
            }
            return View("Index", userDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMyInfo(UserDto user)
        {
            try
            {
                if (user.EMAIL != null && user.PASSWORD != null)
                {
                    var pass = _tokenProvider.EncryptString(user.PASSWORD);
                    var userToken = _tokenProvider.LoginUser(user.EMAIL.Trim(), pass);

                    if (userToken != null)
                    {
                        UserDto loggedUser = new UserDto();
                        if (User.Identity.IsAuthenticated)
                        {
                            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                            var userClaims = claimsIdentity.Claims;

                            if (HttpContext.User.Identity.IsAuthenticated)
                            {
                                foreach (var claim in userClaims)
                                {
                                    var cType = claim.Type;
                                    var cValue = claim.Value;

                                    switch (cType)
                                    {
                                        case "ID":
                                            loggedUser.ID = cValue;
                                            break;
                                    }
                                }
                                user.ID = loggedUser.ID;

                                _employeeRepository.UpdateMyInfo(user);
                                HttpContext.Session.Clear();
                                HttpContext.Session.SetString("JWToken", userToken);

                            }

                            return RedirectToAction(nameof(Index));

                        }
                    }
                    else
                        return NotFound("Yanlış şifre");
                }
                else
                    return NotFound("Hatalı Giriş");
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMyPassword(string p1, string p2, string p3)
        {
            try
            {
                if (p2 == p3 && p1 != null && p2 != null && p3 != null)
                {
                    UserDto loggedUser = new UserDto();
                    if (User.Identity.IsAuthenticated)
                    {
                        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                        var userClaims = claimsIdentity.Claims;

                        if (HttpContext.User.Identity.IsAuthenticated)
                        {
                            foreach (var claim in userClaims)
                            {
                                var cType = claim.Type;
                                var cValue = claim.Value;

                                switch (cType)
                                {
                                    case "ID":
                                        loggedUser.ID = cValue;
                                        break;
                                    case ClaimTypes.Email:
                                        loggedUser.EMAIL = cValue;
                                        break;
                                }
                            }
                            var pass = _tokenProvider.EncryptString(p1);

                            var userToken = _tokenProvider.LoginUser(loggedUser.EMAIL.Trim(), pass);

                            if (userToken != null)
                            {
                                var newPass = _tokenProvider.EncryptString(p2);
                                _employeeRepository.UpdateMyPass(Convert.ToInt16(loggedUser.ID), newPass);
                                HttpContext.Session.Clear();
                            }
                            else
                                return NotFound("Mevcut Şifre Yanlış");
                        }

                        return RedirectToAction("Index", "LogIn");

                    }

                }
                else
                    return NotFound("Şifreler eşleşmiyor");
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
