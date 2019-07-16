using SimpleWebchat.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.DAL.Contexts
{
    public class SimpleWebchatContext : DbContext
    {
        public SimpleWebchatContext():base("SimpleWebchatConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
