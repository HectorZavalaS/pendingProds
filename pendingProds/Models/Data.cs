using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Models
{
    public class Data
    {
        public string status { get; set; }
        public Message message { get; set; }
        public List<Employee> data { get; set; }
    }
}