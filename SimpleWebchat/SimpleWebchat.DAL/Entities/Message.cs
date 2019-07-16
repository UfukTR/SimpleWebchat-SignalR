using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebchat.DAL.Entities
{
    public class Message
    {
        [Key]
        [Column("MessageID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }
        [Column("MessageText")]
        [MaxLength(500)]
        public string MessageText { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
