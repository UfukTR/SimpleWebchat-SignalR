using SimpleWebchat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.BLL.Service
{
    public interface IMessageService
    {
        List<Message> GetMessage(int userID);
        List<Message> GetMessageAll();
    }
}
