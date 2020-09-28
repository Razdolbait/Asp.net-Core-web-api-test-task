using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Mail> Mails { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
