using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.BLL.ViewModels
{
    public class MessageViewmodel
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public string MessageText { get; set; }
    }
}
