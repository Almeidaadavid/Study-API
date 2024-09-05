using API.Domain.Model.EmployeeAggregate;
using API.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Ignorar a tabela employee na migration.
            modelBuilder.Entity<Employee>().ToTable("employee").Metadata.SetIsTableExcludedFromMigrations(true);
        }

    }
}
