using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Models
{
    public class Employee
    {


        public int id { get; set ; }
        public string type { get; set; }
        public Attributes attributes { get; set; }

        public Employee()
        {
            //attributes = new Attributes();
        }
    }
}