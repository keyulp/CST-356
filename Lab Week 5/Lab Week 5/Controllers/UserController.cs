using System.Web.Mvc;
using Lab_Week_5.Models.View;
using Lab_Week_5.Services;

namespace Lab_Week_5.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                _userService.SaveUser(userViewModel);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var userViewModels = _userService.GetAllUsers();

            return View(userViewModels);
        }

        public ActionResult Details(int id)
        {
            var userViewModel = _userService.GetUser(id);

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return RedirectToAction("List");
        }
    }
}