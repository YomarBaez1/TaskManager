using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerTest
{
    internal class HttpRequest
    {
        static HttpClient client = new HttpClient();
        public static async Task<object> Post(string url, object _params)
        {
            var json = JsonConvert.SerializeObject(_params);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }

    }
}
