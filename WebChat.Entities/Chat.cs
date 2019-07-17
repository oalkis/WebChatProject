using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebChat.Entities
{
    public partial class Chat:IEntity
    {
        [Required]
        [Key]
        public int ChatId { get; set; }
        [Required]

        public int UserId { get; set; }
        [Required]

        [Column(TypeName = "VARCHAR(1000)")]
        public string Messages { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual User User { get; set; }

    }
}
