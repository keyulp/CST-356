using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab_Week_5.Data;
using Lab_Week_5.Data.Entities;
using Lab_Week_5.Models.View;
using Lab_Week_5.Repositories;


namespace Lab_Week_5.Controllers
{
    public class KidController : Controller
    {
        private readonly Repository _repository;

        public KidController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(KidViewModel kidViewModel)
        {
            if (ModelState.IsValid)
            {
                var kid = MapToKid(kidViewModel);

                _repository.SaveKid(kid);

                return RedirectToAction("List", new { UserId = kidViewModel.UserId});
            }

            return View();
        }

        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var kidViewModels = new List<KidViewModel>();

            var kidList = _repository.GetKidsForUser(userId);

            foreach (var kid in kidList)
            {
                kidViewModels.Add(MapToKidViewModel(kid));
            }

            return View(kidViewModels);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kid = MapToKidViewModel(_repository.GetKid(id));

            return View(kid);
        }

        [HttpPost]
        public ActionResult Edit(KidViewModel kidViewModel)
        {
            if (ModelState.IsValid)
            {
                var kid = _repository.GetKid(kidViewModel.Id);

                CopyToKid(kidViewModel, kid);

                _repository.UpdateKid(kid);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var pet = MapToKidViewModel(_repository.GetKid(id));

            _repository.DeleteKid(id);

            return RedirectToAction("List", new { UserId = pet.UserId });
        }

        private Kid MapToKid(KidViewModel kidViewModel)
        {
            return new Kid
            {
                Id = kidViewModel.Id,
                FirstName = kidViewModel.FirstName,
                LastName = kidViewModel.LastName,
                Age = kidViewModel.Age,
                Parent1 = kidViewModel.Parent1,
                Parent2 = kidViewModel.Parent2,
                Birthday = kidViewModel.Birthday,
                UserId = kidViewModel.UserId
            };
        }

        private KidViewModel MapToKidViewModel(Kid kid)
        {
            return new KidViewModel
            {
                Id = kid.Id,
                FirstName = kid.FirstName,
                LastName = kid.LastName,
                Age = kid.Age,
                Parent1 = kid.Parent1,
                Parent2 = kid.Parent2,
                Birthday = kid.Birthday,
                UserId = kid.UserId
            };
        }

        private void CopyToKid(KidViewModel kidViewModel, Kid kid)
        {
            kid.Id = kidViewModel.Id;
            kid.FirstName = kidViewModel.FirstName;
            kid.LastName = kidViewModel.LastName;
            kid.Age = kidViewModel.Age;
            kid.Parent1 = kidViewModel.Parent1;
            kid.Parent2 = kidViewModel.Parent2;
            kid.Birthday = kidViewModel.Birthday;
            kid.UserId = kidViewModel.UserId;
        }
    }
}