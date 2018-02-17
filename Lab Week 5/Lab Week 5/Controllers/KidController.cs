using System.Collections.Generic;
using System.Web.Mvc;
using Lab_Week_5.Data.Entities;
using Lab_Week_5.Models.View;
using Lab_Week_5.Services;


namespace Lab_Week_5.Controllers
{
    public class KidController : Controller
    {
        private readonly IKidService _kidService;

        public KidController(IKidService kidService)
        {
            _kidService = kidService;
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
                _kidService.SaveKid(kidViewModel);

                return RedirectToAction("List", new { UserId = kidViewModel.UserId });
            }

            return View();
        }

        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var kidViewModels = _kidService.GetKidsForUser(userId);

            return View(kidViewModels);
        }

        public ActionResult Details(int id)
        {
            var kidViewModel = _kidService.GetKid(id);

            return View(kidViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kid = _kidService.GetKid(id);

            return View(kid);
        }

        [HttpPost]
        public ActionResult Edit(KidViewModel kidViewModel)
        {
            if (ModelState.IsValid)
            {
                _kidService.UpdateKid(kidViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var pet = _kidService.GetKid(id);

            _kidService.DeleteKid(id);

            return RedirectToAction("List", new { UserId = pet.UserId });
        }
    }
}