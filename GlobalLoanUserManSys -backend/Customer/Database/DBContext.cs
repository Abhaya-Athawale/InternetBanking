using Customer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Customer.Database
{
    public class DBContext : DbContext
    {
        public DbSet<customer> customers { get; set; }
        public DbSet<customerLogin> customerLogins { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=True");
        }
    }
}
