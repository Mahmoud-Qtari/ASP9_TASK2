using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK2.Data;
using TASK2.Models;

namespace TASK2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        { 
            this.context = context;
        }
        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Active()
        {
            var UnActiveUser = new List<User>();
            var users = context.Users.ToList();
            foreach(var user in users)
            {
                if(!user.IsActive)
                {
                    UnActiveUser.Add(user);
                }
            }
            return View(UnActiveUser);
        }

        public IActionResult UnActive()
        {
            var ActiveUser = new List<User>();
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                if (user.IsActive)
                {
                    ActiveUser.Add(user);
                }
            }
            return View(ActiveUser);
        }

        public IActionResult ChangeActive(int id)
        {
            var user = context.Users.Find(id);
            user.IsActive = !(user.IsActive);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
