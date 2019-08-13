using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestClientModel.Models
{
    public class Property
    {
        public long ID { get; set; }
        public String ComputerMake { get; set; }
        public String ComputerModel { get; set; }
        public String Processor { get; set; }
        public DateTime IssueDate { get; set; }
        public String SerialNumber { get; set; }
        public Int16 Ram { get; set; }
        public Int16 HardDrive { get; set; }
        public String CellPhoneMake { get; set; }
        public String CellPhoneModel { get; set; }
        public Double CellPhoneNumber { get; set; }
    }
}