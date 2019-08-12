using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestClientModel.Models
{ 
    public class Vehicles
    {
        public long ID { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public Double Year { get; set; }
        public Double Price { get; set; }
        public Boolean Used { get; set; }
        public Boolean New { get; set; }
        public String Color { get; set; } 
    }
}