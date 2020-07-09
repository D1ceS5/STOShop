using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models.Repository
{
    public class Repository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Car> Cars { get { return context.Car; } }
        public IEnumerable<Cart> Carts { get { return context.Cart; } }

        public IEnumerable<Category> Categories { get { return context.Category; } }
        public IEnumerable<Client> Clients { get { return context.Client; } }
        public IEnumerable<Good> Goods { get { return context.Good; } }
        public IEnumerable<Master> Masters { get { return context.Master; } }

        public IEnumerable<Order> Orders { get { return context.Order; } }

        public IEnumerable<Service> Services { get { return context.Service; } }
    }
}