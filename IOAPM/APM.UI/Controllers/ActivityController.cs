using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;

namespace APM.UI.Controllers
{
    [Authorize(Roles.NORMAL, Roles.ADMIN)]
    public class ActivityController : Controller
    {
        readonly IActivityRepository _activityRepository;
        readonly IEmployeeRepository _employeeRepository;
        public ActivityController(IActivityRepository activityRepository, IEmployeeRepository employeeRepository)
        {
            _activityRepository = activityRepository;
            _employeeRepository = employeeRepository;
        }
        [Authorize(Roles.ADMIN)]
        public IActionResult Index()
        {
            DateTime date = DateTime.Now;
            var model = _activityRepository.GetMonthList();
            ViewData["fromDate"] = "01." + date.Month + "." + date.Year;
            ViewData["toDate"] = DateTime.DaysInMonth(date.Year, date.Month) + "." + date.Month + "." + date.Year;
            return View(model);
        }

        [Authorize(Roles.ADMIN)]
        [HttpPost]
        public IActionResult Index(DateTime from, DateTime to)
        {
            var model = _activityRepository.GetDateRangeList(from, to);

            ViewData["fromDate"] = from.ToString("dd/MM/yyyy");
            ViewData["toDate"] = to.ToString("dd/MM/yyyy");
            return View(model);
        }
        

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public JsonResult Create(ActivityDto activity)
        {
            try
            {
                if (activity.PROJECT_NUMBER == null)
                    return Json(new { status = false, error = "Proje seçimi yapınız.." });
                else if (activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "Aktivite tarihi boş bırakılamaz.." });
                else if (activity.START_TIME == null)
                    return Json(new { status = false, error = "Başlangıç saati boş bırakılamaz.." });
                else if (activity.WHOUR == 0)
                    return Json(new { status = false, error = "Çalışma saati boş bırakılamaz.." });
                else if (activity.ACTIVITY_DETAIL == null)
                    return Json(new { status = false, error = "Detay boş bırakılamaz.." });
                else if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "Aktivite başlangıç saati bitişinden küçük olamaz.." });


                var claimsIndentity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = claimsIndentity.Claims;
                string id = "", newName = "";
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
                            case ClaimTypes.Name:
                                newName = cValue;
                                break;
                            case ClaimTypes.Surname:
                                newName += " " + cValue;
                                break;
                        }
                    }
                }
                if (activity.CREATOR == 0)
                {
                    activity.CREATOR = Convert.ToInt16(id);
                    activity.ACTIVITY_EMPLOYEE = Convert.ToInt16(id);
                }
                else
                {
                    activity.ACTIVITY_EMPLOYEE = activity.CREATOR;

                    var emp = _employeeRepository.Get(activity.CREATOR);
                    newName = emp.NAME + " " + emp.SURNAME;
                }
                activity.WHOUR = Math.Round(activity.WHOUR, 2);


                _activityRepository.Create(activity);
                var newId = _activityRepository.GetLastActivityId();
                return Json(new { status = true, id = newId, name = newName });
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        [HttpPost]
        public JsonResult Edit(ActivityDto activity)
        {
            try
            {
                if (activity.PROJECT_NUMBER == null)
                    return Json(new { status = false, error = "Proje seçimi yapınız.." });
                else if (activity.ACTIVITY_DATE == DateTime.MinValue)
                    return Json(new { status = false, error = "Aktivite tarihi boş bırakılamaz.." });
                else if (activity.START_TIME == null)
                    return Json(new { status = false, error = "Başlangıç saati boş bırakılamaz.." });
                else if (activity.WHOUR == 0)
                    return Json(new { status = false, error = "Çalışma saati boş bırakılamaz.." });
                else if (activity.ACTIVITY_DETAIL == null)
                    return Json(new { status = false, error = "Detay boş bırakılamaz.." });
                else if (activity.END_TIME <= activity.START_TIME)
                    return Json(new { status = false, error = "Aktivite başlangıç saati bitişinden küçük olamaz.." });

                activity.WHOUR = Math.Round(activity.WHOUR, 2);

                _activityRepository.Update(activity);
                return Json(new { status = true });
            }
            catch (Exception e)
            {

                return Json(new { status = false, error = e });
            }
        }

        [HttpPost]
        [Authorize(Roles.ADMIN)]
        public JsonResult Delete(int id)
        {
            try
            {
                _activityRepository.Delete(id);

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
        [HttpPost]
        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public JsonResult MyDelete(int id)
        {
            try
            {
                _activityRepository.Delete(id);

                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }

        [Authorize(Roles.ADMIN, Roles.NORMAL)]
        public IActionResult MyActivity(DateTime? from, DateTime? to)
        {
            DateTime date = DateTime.Now;
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
            if (from == null && to == null)
            {
                var model = _activityRepository.GetMyActivity(Convert.ToInt16(id));

                ViewData["fromDate"] = "01." + date.Month + "." + date.Year;
                ViewData["toDate"] = DateTime.DaysInMonth(date.Year, date.Month) + "." + date.Month + "." + date.Year;

                return View(model);
            }
            else
            {
                if (to == null)
                    to = from;
                var model = _activityRepository.GetMyDateRangeActivity(Convert.ToInt16(id), from, to);

                ViewData["fromDate"] = from?.ToString("dd/MM/yyyy");
                ViewData["toDate"] = to?.ToString("dd/MM/yyyy");

                return View(model);
            }
        }
       
    }
}