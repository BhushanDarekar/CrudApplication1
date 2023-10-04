using CrudApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
