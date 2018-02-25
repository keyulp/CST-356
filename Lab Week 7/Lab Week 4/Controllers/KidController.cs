using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab_Week_4.Data;
using Lab_Week_4.Data.Entities;
using Lab_Week_4.Models.View;


namespace Lab_Week_4.Controllers
{
    public class KidController : Controller
    {
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
                var context = new DatabaseContext();

                var kid = MapToKid(kidViewModel);

                context.Kids.Add(kid);

                context.SaveChanges();

                return RedirectToAction("List", new { UserId = kidViewModel.UserId });
            }

            return View();
        }

        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var kidViewModels = new List<KidViewModel>();

            var context = new DatabaseContext();

            var kidList = context.Kids.Where(pet => pet.UserId == userId).ToList();

            foreach (var kid in kidList)
            {
                var kidViewModel = MapToKidViewModel(kid);
                kidViewModels.Add(kidViewModel);
            }

            return View(kidViewModels);
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
    }
}