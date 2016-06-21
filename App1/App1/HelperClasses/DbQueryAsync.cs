using App1.HelperClasses.Fakes;
using App1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1
{
    public static class DbQueryAsync
    {
        public static async Task<string> GetDataFromRestTestCtrl()
        {
            var client = new HttpClient();
            //var response = client.GetStringAsync();
            //return response.Result;

            var uri = new Uri("http://192.168.1.241:50000/api/Test");

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }

            return null;
        }
    

        public static List<Trail> GetTrails()
        {
            return FakeModels.FakeListOfTrails();
        }

        public static FullTrail GetTrailById(string id)
        {
            return FakeModels.GetFakeFullTrailById(id);
        }
    }

}
