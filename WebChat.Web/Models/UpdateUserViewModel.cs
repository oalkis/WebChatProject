using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Entities;

namespace WebChat.Web.Models
{
    public class UpdateUserViewModel
    {
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
    }
}
