using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class Location
    {
        public string Region { get; set; }
        public bool Selected { get; set; }
        public List<string> Countries { get; set; }
    }
}
