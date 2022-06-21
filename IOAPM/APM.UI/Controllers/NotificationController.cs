using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class NotificationController : Controller
    {
        readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IActionResult Index()
        {
            var model = _notificationRepository.GetList();
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var notifi = _notificationRepository.Get(id);

            if (notifi == null)
                return NotFound("Silinecek birşey bulunamadı !");

            _notificationRepository.Delete(notifi.ID);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public JsonResult Create(NotificationDto notifi)
        {
            try
            {
                if (notifi.START_TIME == DateTime.MinValue)
                    return Json(new { status = false, error = "null", text = "Başlangıç Tarihi Boş Olamaz." });
                else if (notifi.TEXT_INFO == null)
                    return Json(new { status = false, error = "null", text = "Duyuru İçeriği Boş olamaz." });
                else if (notifi.START_TIME >= notifi.END_TIME)
                    return Json(new { status = false, error = "null", text = "Başlangıç Tarihi Bitiş Tarihinden Büyük veya Eşit Olamaz." });

                _notificationRepository.Create(notifi);
                return Json(new { status = true });
            }
            catch (System.Exception)
            {
                return Json(new { status = false, error = "any" });
            }
        }

        [HttpPost]
        public JsonResult Edit(NotificationDto notifi)
        {
            try
            {
                if (notifi.START_TIME == DateTime.MinValue)
                    return Json(new { status = false, error = "null", text = "Başlangıç Tarihi Boş Olamaz." });
                else if (notifi.TEXT_INFO == null)
                    return Json(new { status = false, error = "null", text = "Duyuru İçeriği Boş olamaz." });
                else if (notifi.START_TIME >= notifi.END_TIME)
                    return Json(new { status = false, error = "null", text = "Başlangıç Tarihi Bitiş Tarihinden Büyük veya Eşit Olamaz." });

                _notificationRepository.Update(notifi);
                return Json(new { status = true });
            }
            catch (System.Exception)
            {
                return Json(new { status = false, error = "any" });
            }

        }
    }
}