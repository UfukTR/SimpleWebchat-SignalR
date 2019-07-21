using SimpleWebchat.BLL;
using SimpleWebchat.BLL.Service;
using SimpleWebchat.BLL.ViewModels;
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
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public HomeController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }
        // GET: Home
        public ActionResult Index()
        {
            //UserViewmodel _model = new UserViewmodel();
            //_model.UserVariance = "t5swqre";
            //_model.Username = "deneme";
            //_model.Password = "1234";
            //_model.Email = "ufuk@test.com";
            //_model.UserRole = 1;
            //_userService.UserCreate(_model);
            //_model.UserID = 2;
            //_userService.UserDelete(_model);
            var message = _messageService.GetMessageAll();
            return View();
        }
        public ActionResult Message()
        {
            var message = _messageService.GetMessageAll().ToList();
            List<MessageViewmodel> _Listmodel = new List<MessageViewmodel>();
            foreach (var item in message)
            {
                MessageViewmodel _model = new MessageViewmodel();
                _model.UserID = item.UserID;
                _model.MessageText = item.MessageText;
                _Listmodel.Add(_model);
            }
            return View(_Listmodel);
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