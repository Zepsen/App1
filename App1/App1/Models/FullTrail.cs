using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class FullTrail
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
        
        public string Description { get; set; }
        public string WhyGo { get; set; }
        public double Rate { get; set; }
        public string SeasonStart { get; set; }
        public string SeasonEnd { get; set; }
        public double Elevation { get; set; }
        public int Peak { get; set; }
        public string FullDescription { get; set; }
        public List<string> References { get; set; }
        public List<string> Photos { get; set; }
        //public List<CommentsModel> Comments { get; set; }
    }
}
