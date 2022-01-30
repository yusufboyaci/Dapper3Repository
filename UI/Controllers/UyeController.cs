using DATAACCESS.Abstract;
using ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class UyeController : Controller
    {
        private readonly IUyeRepository _uyeRepository;
        public UyeController(IUyeRepository uyeRepository)
        {
            _uyeRepository = uyeRepository;
        }
        public IActionResult Index()
        {

            return View(_uyeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Insert() => View();
        [HttpPost]
        public IActionResult Insert(Uye uye)
        {

            _uyeRepository.InsertUye(uye);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(Guid id) => View(_uyeRepository.GetById(id));
        [HttpPost]
        public IActionResult Update(Uye uye)
        {
            _uyeRepository.UpdateUye(uye);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _uyeRepository.DeleteUye(id);
            return RedirectToAction("Index");
        }

    }
}
