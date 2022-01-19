using Buisness.Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Context : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<DialogueParticipant> Participants { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureSchema(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ConfigureSchema(ModelBuilder modelBuilder)
        {
            ConfigureUnits(modelBuilder);
        }
        private void ConfigureUnits(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { });
        }
    }
}
