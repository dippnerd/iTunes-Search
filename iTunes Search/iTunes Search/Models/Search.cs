using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iTunes_Search.Models
{
    public class SearchModel
    {
        [Required]
        public string query { get; set; }
        public string media { get; set; }
    }
}