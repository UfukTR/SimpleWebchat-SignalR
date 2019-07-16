using SimpleWebchat.DAL.Contexts;
using SimpleWebchat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.BLL
{
    public class Business
    {
        SimpleWebchatContext simpleWebchatContext = new SimpleWebchatContext();



        User userBLL = new User();
        public string UserVarianceBLL { get; set; }
        public string UsernameBLL { get; set; }
        public string PasswordBLL { get; set; }
        public string EmailBLL { get; set; }
        public int UserRoleBLL { get; set; }



        Message messageBLL = new Message();
        public int MessageID { get; set; }
        public string MessageText { get; set; }        

    }
}
