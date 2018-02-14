using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab_Week_5.Data;
using Lab_Week_5.Data.Entities;
using Lab_Week_5.Models.View;
using Lab_Week_5.Repositories;

namespace Lab_Week_5.Controllers
{
    public class UserController : Controller
    {
        private readonly Repository _repository;

        public UserController(Repository repository)
        {
            _repository = repository;
        }

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

                _repository.SaveUser(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var userViewModels = _repository.GetAllUsers();

            return View(userViewModels);
        }

        public ActionResult Details(int id)
        {
            var userViewModel = _repository.GetUser(id);

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _repository.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.GetUser(userViewModel.Id);

                CopyToUser(userViewModel, user);

                _repository.UpdateUser(user);

                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _repository.DeleteUser(id);

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