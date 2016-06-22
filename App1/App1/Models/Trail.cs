using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class Trail
    {
        public string Id { get; set; }
        public string Difficult { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public double Distance { get; set; }
        public bool DogAllowed { get; set; }
        public bool GoodForKids { get; set; }
        public string Type { get; set; }
        public string DurationType { get; set; }
        public string CoverPhoto { get; set; }
    }

    
}
