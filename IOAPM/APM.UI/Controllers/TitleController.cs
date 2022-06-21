using Microsoft.AspNetCore.Mvc;
using APM.Repository.Authorize;
using APM.Repository.Contracts;
using APM.Repository.Dto;

namespace APM.UI.Controllers
{
    [Authorize(Roles.ADMIN)]
    public class TitleController : Controller
    {
        readonly ITitleRepository _titleRepository;
        public TitleController(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public IActionResult Index()
        {
            var model = _titleRepository.GetList();
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var title = _titleRepository.Get(id);

            if (title == null)
                return NotFound("Silinecek birşey bulunamadı !");

            _titleRepository.DeleteTitle(title.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,NAME")] ConstantDto title)
        {
            if (title.NAME != null)
            {
                _titleRepository.Create(title);
                return RedirectToAction(nameof(Index));
            }

            return View(title);

        }
        public IActionResult Edit(int id)
        {
            var title = _titleRepository.Get(id);
            return View(title);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,NAME")] ConstantDto title)
        {
            if (id != title.ID)
            {
                return NotFound();
            }
            if (title != null)
            {

                _titleRepository.Update(title);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }

    }
}