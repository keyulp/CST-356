using System.Web.Mvc;
using Lab_2.Data;
using Lab_2.Data.Entities;

namespace Lab_2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            InMemoryDatabase.Users.Add(user);


            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var users = InMemoryDatabase.Users;

            return View(users);
        }
    }
}