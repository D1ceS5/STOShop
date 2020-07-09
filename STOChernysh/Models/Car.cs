using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STOChernysh.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }

        public Car(int CarId_, string CarName_, string CarType_, string CarColor_)
        {
            this.CarId = CarId_;
            this.CarName = CarName_;
            this.CarType = CarType_;
            this.CarColor = CarColor_;
        }

        public Car()
        {

        }
    }
}