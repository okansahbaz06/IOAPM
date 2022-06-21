using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using Microsoft.AspNetCore.Mvc;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly ITokenProvider _tokenProvider;
        readonly IPublicHolidays _publicHolidays;
        public EmployeeController(IEmployeeRepository employeeRepository, ITokenProvider tokenProvider, IPublicHolidays publicHolidays)
        {
            _employeeRepository = employeeRepository;
            _tokenProvider = tokenProvider;
            _publicHolidays = publicHolidays;
        }
        public IActionResult Index()
        {
            var model = _employeeRepository.GetList();
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(EmployeeDto employee)
        {
            try
            {
                if (!_employeeRepository.IsAnyEmployee(employee.MAIL))
                {
                    var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
                    var userClaims = claimsIndentity.Claims;
                    string id = "";
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        foreach (var claim in userClaims)
                        {
                            var cType = claim.Type;
                            var cValue = claim.Value;
                            switch (cType)
                            {
                                case "ID":
                                    id = cValue;
                                    break;
                            }
                        }
                    }
                    employee.CREATOR_ID = Convert.ToInt16(id);
                    employee.PASSWORD = _tokenProvider.EncryptString("test");

                    _employeeRepository.Create(employee);
                    return Json(new { status = true });
                }
                else
                    return Json(new { status = false, error = "thereIsEmployee" });
            }
            catch (Exception)
            {

                return Json(new { status = false, error = "any" });
            }
        }

        public JsonResult Edit(EmployeeDto employee)
        {
            try
            {
                _employeeRepository.Update(employee);
                return Json(new { status = true });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var emp = _employeeRepository.Get(id);

                if (emp == null)
                    return NotFound("Silinecek birşey bulunamadı !");

                _employeeRepository.Delete(emp.ID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound("Hata");
            }
        }
        public IActionResult Reports()
        {
            var employeesId = _employeeRepository.GetEmployeesId();

            ViewData["month"] = DateTime.Now.Month;
            ViewData["year"] = DateTime.Now.Year;

            return View(employeesId);
        }
        [HttpPost]
        public IActionResult Reports(List<int> id, int month, int year, List<int> projectId, bool? invoice)
        {
            try
            {
                var reports = _employeeRepository.GetReports(id, month, year, projectId, invoice);
                ViewData["month"] = month;
                ViewData["year"] = year;

                reports.DaysSummary = _publicHolidays.GetMonthHolidays(month, year);

                return View(reports);
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }

    }
}
