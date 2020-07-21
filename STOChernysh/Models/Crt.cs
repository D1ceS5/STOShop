using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Crt
    {
        private List<CrtLine> lineCollection = new List<CrtLine>();

        public void AddItem(Service service, int quantity)
        {
            CrtLine cartLine = lineCollection.Where(p => p.Service.ServiceId == service.ServiceId).FirstOrDefault();
            if (cartLine == null)
            {
                lineCollection.Add(new CrtLine() { Service = service, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }
        public void RemoveLine(Service service)
        {
            lineCollection.RemoveAll(l => l.Service.ServiceId == service.ServiceId);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public decimal ComputeTotalPrice()
        {
            return lineCollection.Sum(e => e.Service.Price * e.Quantity);
        }
        public IEnumerable<CrtLine> Lines
        { get { return lineCollection; } }
    }

    public class CrtLine
    {
        public Service Service { get; set; }
        public int Quantity { get; set; }
    }
}