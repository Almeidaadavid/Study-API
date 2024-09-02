using API.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
