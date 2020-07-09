using System.Data.Entity;

namespace STOChernysh.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Master> Master { get; set; }
        public DbSet<Good> Good { get; set; }

    }
}