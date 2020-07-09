using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public Category(int CategoryId_, string Name_)
        {
            this.CategoryId = CategoryId_;
            this.Name = Name_;
        }
        public Category()
        {
            
        }
    }
}