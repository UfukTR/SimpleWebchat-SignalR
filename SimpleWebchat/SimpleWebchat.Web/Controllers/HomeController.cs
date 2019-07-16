using SimpleWebchat.BLL;
using SimpleWebchat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebchat.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult GetMessages()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            var model = _messageRepository.GetAllMessages();
            return PartialView("_MessagesList", model);
        }
    }
}