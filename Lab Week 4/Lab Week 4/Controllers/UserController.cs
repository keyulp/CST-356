using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab_Week_4.Data;
using Lab_Week_4.Data.Entities;
using Lab_Week_4.Models.View;

namespace Lab_Week_4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = MapToUser(userViewModel);

                var context = new DatabaseContext();

                context.Users.Add(user);

                context.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var userViewModels = new List<UserViewModel>();

            var context = new DatabaseContext();

            foreach (var user in context.Users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return View(userViewModels);
        }

        public ActionResult Details(int id)
        {
            var context = new DatabaseContext();

            var userToFind = context.Users.Find(id);

            var user = MapToUserViewModel(userToFind);

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            var context = new DatabaseContext();

            var userToFind = context.Users.Find(id);

            var user = MapToUserViewModel(userToFind);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                var context = new DatabaseContext();

                var user = context.Users.Find(userViewModel.Id);

                CopyToUser(userViewModel, user);

                context.SaveChanges();

                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var context = new DatabaseContext();

            var user = context.Users.Find(id);

            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }

            return RedirectToAction("List");
        }



        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DOB,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DateOfBirth,
                YearsInSchool = user.YearsInSchool
            };
        }


        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DateOfBirth = userViewModel.DOB;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }
    }
}