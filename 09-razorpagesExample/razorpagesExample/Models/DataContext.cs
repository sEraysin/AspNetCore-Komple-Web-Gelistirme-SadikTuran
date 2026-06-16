using Microsoft.EntityFrameworkCore;

namespace razorpagesExample.Models
{
    public class DataContext : DbContext
    {
       
        public DataContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RazorDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");
            }
        }
    }
}