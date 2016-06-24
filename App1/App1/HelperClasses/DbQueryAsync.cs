﻿using App1.HelperClasses.Fakes;
using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1
{
    public static class DbQueryAsync
    {
        static HttpClient client = new HttpClient{BaseAddress = new Uri("http://192.168.1.241:50000/")};

        public static List<Trail> GetTrails()
        {
            var response = client.GetAsync("api/Trails").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Trail>>(content);
            };

            return null;
            //return FakeModels.FakeListOfTrails();
        }        

        public static FullTrail GetTrailById(string id)
        {
            var response = client.GetAsync($"api/Trails/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<FullTrail>(content);
            };

            return null;
            //return FakeModels.GetFakeFullTrailById(id);
        }

        public static List<Location> GetLocations()
        {
            var response = client.GetAsync("api/Locations").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Location>>(content);
                
            };

            return null;
            //return FakeModels.FakeListOfTrails();
        }
    }

}
