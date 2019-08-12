using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestClientModel.Models
{
    public class Person
    {
        public long ID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public Double PayRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public String State { get; set; }
        public long ZipCode { get; set; }
        public Double PhoneNumber { get; set; }

    }
}