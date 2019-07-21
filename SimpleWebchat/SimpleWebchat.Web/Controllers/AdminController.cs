using SimpleWebchat.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebchat.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _IuserService;
        public AdminController(IUserService IuserService)
        {
            _IuserService = IuserService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var UserList = _IuserService.GetAllUser();
            return View(UserList);
        }
    }
}