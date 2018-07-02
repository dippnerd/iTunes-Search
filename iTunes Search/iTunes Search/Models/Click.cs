using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTunes_Search.Models
{
    public class Click
    {
        public int id { get; set; }
        public string type { get; set; }
        public string search { get; set; }
        public string name { get; set; }
    }
}