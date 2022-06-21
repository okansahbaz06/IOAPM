using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using Microsoft.AspNetCore.Mvc;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class PriorityController : Controller
    {
        readonly IPriorityRepository _priorityRepository;

        public PriorityController(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public IActionResult Index()
        {
            var model = _priorityRepository.GetList();
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var priority = _priorityRepository.Get(id);

            if (priority == null)
                return NotFound("Silinecek birşey bulunamadı !");

            _priorityRepository.DeletePriority(priority.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,NAME")] ConstantDto priority)
        {
            if (priority.NAME != null)
            {
                _priorityRepository.Create(priority);
                return RedirectToAction(nameof(Index));
            }

            return View(priority);

        }

        public IActionResult Edit(int id)
        {
            var title = _priorityRepository.Get(id);
            return View(title);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,NAME")] ConstantDto priority)
        {
            if (id != priority.ID)
            {
                return NotFound();
            }
            if (priority != null)
            {

                _priorityRepository.Update(priority);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
