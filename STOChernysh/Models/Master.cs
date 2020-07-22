using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Master
    {
        public int MasterId { get; set; }
        public string Name { get; set; }
        public int User_UerId { get; set; }
        public Master(int MasterId_, string Name_)
        {
            this.MasterId = MasterId_;
            this.Name = Name_;
        }
        public Master()
        {

        }

    }
}