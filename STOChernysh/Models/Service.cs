using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<Order> Order { get; set; }

        public int Categories_CategoryId{ get; set; }
        public virtual IEnumerable<Master> Master { get; set; }
        public virtual IEnumerable<Car> Car { get; set; }


        public Service(int ServiceId_, string Name_, string Description_)
        {
            this.ServiceId = ServiceId_;
            this.Name = Name_;
            this.Description = Description_;
           
        }
        public Service()
        {

        }
    }
}