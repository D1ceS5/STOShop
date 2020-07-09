using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string SessionKey { get; set; }
        public decimal Price { get; set; }
        public virtual IEnumerable<Service> Service { get; set; }

        public Cart(int CartId_, string SessionKey_, decimal Price_)
        {
            this.CartId = CartId_;
            this.SessionKey = SessionKey_;
            this.Price = Price_;
            
        }
        public Cart()
        {

        }
    }
}