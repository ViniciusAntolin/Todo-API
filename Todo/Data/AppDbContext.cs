using Microsoft.EntityFrameworkCore;
using Todo.Data.Interface;
using Todo.Models;

namespace Todo.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<TodoModel> TodoSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
