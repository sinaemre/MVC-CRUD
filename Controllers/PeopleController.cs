using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CRUD.Entities.Concrete;
using MVC_CRUD.Infrastructure.Services.Interface;
using MVC_CRUD.Models.DTO_s;
using MVC_CRUD.Models.ViewModels;

namespace MVC_CRUD.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepo;

        public PeopleController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public IActionResult Index()
        {
            var people = _personRepo.GetByDefaults(x => x.Status != Entities.Abstract.Status.Passive);

            return View(people);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var person = _personRepo.GetByDefault(x => x.Id == id && x.Status != Entities.Abstract.Status.Passive);
            if (person != null)
            {
                var model = new DetailPersonVM();
                model.Id = person.Id;
                model.Name = person.Name;
                model.Surname = person.Surname;
                model.Birthdate = person.Birthdate;
                model.Gender = person.Gender;
                model.Status = person.Status;
                return View(model);
            }
            TempData["Error"] = "Kişi bulunamadı!";
            return RedirectToAction("Index");
        }



        [HttpGet] //Birşey yazmasak default olarak HttpGet'dir.
        public IActionResult CreatePerson()
        {
            ViewBag.Genders = (Enum.GetValues(typeof(Gender)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(Gender), e), Value = e.ToString() })).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonDTO model)
        {
            ViewBag.Genders = (Enum.GetValues(typeof(Gender)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(Gender), e), Value = e.ToString() })).ToList();

            //DTO'da verilen kurallara uyululmuş mu diye kontrol eder.
            if (ModelState.IsValid)
            {
                var person = new Person();
                person.Name = model.Name;
                person.Surname = model.Surname;
                person.Birthdate = model.Birthdate;
                person.Gender = model.Gender;
                _personRepo.Add(person);
                TempData["Success"] = "Kişi eklendi!";
                return RedirectToAction("Index");
            }

            //Eğer ki kurallara uyulmazsa View'e modeli geri göndersin.
            TempData["Error"] = "Aşağıdaki kurallara uyunuz!";
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePerson(int id)
        {
            ViewBag.Genders = (Enum.GetValues(typeof(Gender)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(Gender), e), Value = e.ToString() })).ToList();

            var person = _personRepo.GetByDefault(x => x.Id == id && x.Status != Entities.Abstract.Status.Passive);
            if (person is not null)
            {
                var model = new UpdatePersonDTO();
                model.Name = person.Name;
                model.Surname = person.Surname;
                model.Birthdate = person.Birthdate;
                model.Gender = person.Gender;

                return View(model);
            }

            TempData["Error"] = "Kişi bulunamadı!!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePerson(UpdatePersonDTO model)
        {
            if (ModelState.IsValid)
            {
                var person = _personRepo.GetByDefault(x => x.Id == model.Id && x.Status != Entities.Abstract.Status.Passive);
                if (person != null)
                {
                    person.Name = model.Name;
                    person.Surname = model.Surname;
                    person.Birthdate = model.Birthdate;
                    person.Gender = model.Gender;
                    _personRepo.Update(person);
                    TempData["Success"] = "Kişi bilgileri güncellendi!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Kişi bulunamadı!!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Aşağıdaki kurallara uyunuz!";
            return View(model);
        }

        [HttpGet]
        public IActionResult DeletePerson(int id)
        {
            var person = _personRepo.GetByDefault(x => x.Id == id && x.Status != Entities.Abstract.Status.Passive);
            if (person is not null)
            {
                _personRepo.Delete(person);
                TempData["Success"] = "Kişi silindi!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Kişi bulunamadı!";
            return RedirectToAction("Index");
        }

    }
}
