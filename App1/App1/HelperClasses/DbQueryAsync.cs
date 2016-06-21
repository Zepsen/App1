using App1.HelperClasses.Fakes;
using App1.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace App1
{
    public static class DbQueryAsync
    {
        public static string GetDataFromRestTestCtrl()
        {
            var client = new HttpClient();
            var response = client.GetStringAsync("http://echo.jsontest.com/title/ipsum/content/blah");
            return response.Result;
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
