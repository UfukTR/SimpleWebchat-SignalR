using SimpleWebchat.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleWebchat.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
           var user= _userService.Login(username, password);
            if (user.UserRole==1)
            {
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Admin", action = "Index" }));
            }
            else if (user.UserRole==2)
            {
                return RedirectToAction("Message", new RouteValueDictionary(new { controller = "Home", action = "Message" }));
            }
            {
                return View();
            }
           
        }
    }
}