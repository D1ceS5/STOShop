using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите хоть один адресс доставки!")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Введите город для получения!")]
        public string City { get; set; }
        public decimal Price { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Service Service { get; set; }
        public int Quantity { get; set; }

    }
}