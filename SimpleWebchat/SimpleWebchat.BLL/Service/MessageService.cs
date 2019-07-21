using SimpleWebchat.DAL.Entities;
using SimpleWebchat.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.BLL.Service
{
    public class MessageService:IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public List<Message> GetMessage(int userID)
        {
            return _messageRepository.GetAll(x => x.UserID == userID).ToList();
        }

        public List<Message> GetMessageAll()
        {
            return _messageRepository.GetAll().ToList();
        }
    
    }
}
