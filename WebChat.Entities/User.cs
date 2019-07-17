using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebChat.Entities
{
   public partial class User:IEntity

    {
        public User()
        {
            this.Chats = new List<Chat>();
        }
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }

    }
}
