using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleWebchat.Web.Hubs
{
    public class MessagesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["SimpleWebchatConnection"].ToString();

        public void SendMessage(string name, string message)
        {
            Clients.Others.GetMessageOther(name, message); // Mesajı alanlar isim ve iletiyi görecek.
            Clients.Caller.GetMessageCaller(message); // Mesaj gönderen sadece iletisini görecek.

            string id = Context.ConnectionId;
            Clients.Client(id).GetMessageCaller(id); //Eşsiz ID bu şekilde yakalanıyor.
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
        }
    }
    
}