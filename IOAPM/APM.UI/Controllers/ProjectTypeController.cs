using Microsoft.AspNetCore.Mvc;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class ProjectTypeController : Controller
    {
        readonly IProjectTypeRepository _projectTypeRepository;
        public ProjectTypeController(IProjectTypeRepository projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        public IActionResult Index()
        {
            var model = _projectTypeRepository.GetList();
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var projectType = _projectTypeRepository.Get(id);

            if (projectType == null)
                return NotFound("Silinecek birşey bulunamadı !");

            _projectTypeRepository.DeleteProjectType(projectType.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,NAME")] ConstantDto projectType)
        {
            if (projectType.NAME != null)
            {
                _projectTypeRepository.Create(projectType);
                return RedirectToAction(nameof(Index));
            }

            return View(projectType);

        }
        public IActionResult Edit(int id)
        {
            var projectType = _projectTypeRepository.Get(id);
            return View(projectType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,NAME")] ConstantDto projectType)
        {
            if (id != projectType.ID)
            {
                return NotFound();
            }
            if (projectType != null)
            {

                _projectTypeRepository.Update(projectType);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }
    }
}