using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Order.Add(order);
                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Service).State = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Order.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                  
                    dbOrder.City = order.City;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }

        public void SaveGame(Service service)
        {
            if (service.ServiceId == 0)
            {
                service = context.Service.Add(service);
            }
            else
            {
                Service dbGame = context.Service.Find(service.ServiceId);
                if (dbGame != null)
                {
                    dbGame.Name = service.Name;
                    dbGame.Price = service.Price;
                    dbGame.Categories_CategoryId = service.Categories_CategoryId;
                    dbGame.Description = service.Description;
                }
            }
            context.SaveChanges();
        }
        public void DeleteGame(Service game)
        {
            IEnumerable<Order> orders = context.Order.Include(o=>o.OrderLines.Select(ol=>ol.Service)).Where(o => o.OrderLines.Count(ol => ol.Service.ServiceId == game.ServiceId) > 0).ToArray();
            foreach (Order order in orders)
            {
                context.Order.Remove(order);
            }
            context.Service.Remove(game);
            context.SaveChanges();
        }

    }
}