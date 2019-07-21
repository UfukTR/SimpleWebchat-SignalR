using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.DAL.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Messages = new List<Message>();
        }
        [Key]
        [Column("UserID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Column("UserVariance")]
        [MaxLength(50)]
        public string UserVariance { get; set; }
        [Required]
        [Column("Username")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [Column("Email")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("UserRole")]
        public int UserRole { get; set; }

        public List<Message> Messages { get; set; }
    }
}
