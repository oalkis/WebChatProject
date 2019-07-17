using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Entities;

namespace WebChat.DAL
{
   public class DatabaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=94.73.170.2;Database=u8490078_db367;User Id=u8490078_user367;Password=RDpf83I6;Trusted_Connection=false");
        

        }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
      
    }
}
