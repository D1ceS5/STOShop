using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Good_Id { get; set; }

        public Order(int OrderId_, int Good_Id_)
        {
            this.OrderId = OrderId_;
            this.Good_Id = Good_Id_;
        }
        public Order()
        {

        }
    }
}