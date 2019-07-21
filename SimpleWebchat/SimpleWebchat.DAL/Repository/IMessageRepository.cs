using SimpleWebchat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.DAL.Repository
{
    
    public interface IMessageRepository : IRepository<Message>
    {
    }
}
