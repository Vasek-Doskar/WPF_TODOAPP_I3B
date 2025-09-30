using Microsoft.EntityFrameworkCore;
using WPF_TODOAPP.Models;

namespace WPF_TODOAPP.Database
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<ToDoEntity> ToDoSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = ToDoAppDb.db");
        }
    }
}
