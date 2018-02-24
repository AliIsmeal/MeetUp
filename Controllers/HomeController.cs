using meet_up.Extensions;
using meet_up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace meet_up.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetFullName()
        {
            var db = ApplicationDbContext.Create();
            var userId = Request.IsAuthenticated ? HttpContext.User.Identity.GetUserId() : null;
            var user = db.Users.FirstOrDefault(f => f.Id == userId);
            var userO = new UserViewModel
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                
                Email = user.Email
            };
                
                           

            return View(userO);
        }
        public async Task<ActionResult> Users()
        {
            var users = new List<UserViewModel>();
            await users.GetUsers();

            return View(users);
        }

        


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}