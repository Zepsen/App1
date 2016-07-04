using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models.HelperModel
{
    public class UpdatedOptionModel
    {
        public double Distance { get; set; }
        public int Peak { get; set; }
        public double Elevation { get; set; }
        public string SeasonStart { get; set; }
        public string SeasonEnd{ get; set; }
        public bool DogAllowed { get; set; }
        public bool GoodForKids { get; set; }
        public string Type { get; set; }
        public string DurationType { get; set; }        
    }
}
