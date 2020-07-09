using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models.Repository
{
    public class Repository
    {
        EFDbContext context = new EFDbContext();

        public List<Car> Car { get { return context.Car.ToList(); } }
        public List<Cart> Cart { get { return context.Cart.ToList(); } }

        public List<Category> Category { get { return context.Category.ToList(); } }
        public List<Client> Client { get { return context.Client.ToList(); } }
        public List<Good> Good { get { return context.Good.ToList(); } }
        public List<Master> Master{ get { return context.Master.ToList(); } }

        public List<Order> Order { get { return context.Order.ToList(); } }

        public List<Service> Service { get { return context.Service.ToList(); } }
    }
}