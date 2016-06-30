using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.HelperClasses.Fakes
{
    public static class FakeModels
    {
        static Random rand = new Random();

        public static Trail FakeTrail()
        {            
            return new Trail
            {
                Id = rand.Next(1, 100).ToString(),
                Name = "FakeName" + rand.Next(1, 100),
                Difficult = "Easy",   
                Country = "Fake Country",
                CoverPhoto = "trail.jpg",
                DogAllowed = true,
                Region = "Europe"

            };
        }

        public static List<Trail> FakeListOfTrails()
        {
            return new List<Trail>
            {
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                FakeTrail(),
                //FakeTrail()
            };
        }

        public static FullTrail GetFakeFullTrailById(string id)
        {
            return new FullTrail
            {
                Id = id,
                Difficult = "Easy",
                Name = "FakeName" + id,
                Region = "FakeRegion",
                Country = "FakeCountry",
                State = "FakeState",
                Distance = 1000,
                GoodForKids = true,
                Type = "loop",
                DurationType = "weekend",
                CoverPhoto = "trail.jpg",
                Description = "Fake description " + new string('*', 100),
                DogAllowed = true,
                Elevation = 10.2,
                FullDescription = "Fake full description " + new string('*', 100),
                Peak = 1000,
                Photos = new List<string> { "trail1.jpg", "trail2.jpg" },
                Rate = 3.3,
                References = new List<string> { "http://google.com" },
                SeasonEnd = "May",
                SeasonStart = "March",
                WhyGo = "Fake whygo " + new string('*', 100),
                Comments = new List<Comments>()
            };
        }

        public static List<Location> GetFakeLocationsList()
        {
            return new List<Location>
            {
                GetFakeLocation()
            };
        }

        private static Location GetFakeLocation()
        {
            return new Location
            {
                Region = "Europe"
            };
        }
    }
}
