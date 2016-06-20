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

        public static Trails FakeTrail()
        {
            return new Trails
            {
                Id = rand.Next(1, 100).ToString(),
                Name = "FakeTrail" + rand.Next(1, 100),
                Difficult = "Easy",
                Rate = rand.NextDouble() * 10
            };
        }

        public static List<Trails> FakeListOfTrails()
        {
            return new List<Trails>
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
    }
}
