using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebchat.BLL.ViewModels
{
    public class UserViewmodel
    {
        public int UserID { get; set; }
        
        public string UserVariance { get; set; }
        
        public string Username { get; set; }
 
        public string Password { get; set; }
       
        public string Email { get; set; }
      
        public int UserRole { get; set; }
    }
}