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
        public String Used { get; set; }
        public String New { get; set; }
        public String Color { get; set; }
    }
}