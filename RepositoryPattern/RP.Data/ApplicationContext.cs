using Microsoft.EntityFrameworkCore;

namespace RP.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EmployeeMap(modelBuilder.Entity<Employee>());
        }
    }
}
