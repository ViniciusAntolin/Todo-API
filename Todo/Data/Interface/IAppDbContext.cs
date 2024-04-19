using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data.Interface
{
    public interface IAppDbContext
    {
        public DbSet<TodoModel> TodoSet { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
