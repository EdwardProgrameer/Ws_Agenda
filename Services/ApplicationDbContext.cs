using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ws_Agenda.Models;

namespace Ws_Agenda.Services
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<User> tb_users { get; set; }
        public DbSet<User_Registrer> tb_user_Registred { get; set; }
    }
}
