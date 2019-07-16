using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebchat.Web.Models
{
    public class Messages
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public string MessageText { get; set; }
    }
}