using App1.Models.HelperModel;
using System.Collections.Generic;

namespace App1.Models
{
    public class Option
    {
        public List<SimpleModel> Seasons { get; set; }
        public List<SimpleModel> TrailsTypes { get; set; }
        public List<SimpleModel> TrailsDurationTypes { get; set; }
    }
}
