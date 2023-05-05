using Newtonsoft.Json;
using System;
using System.Web;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    internal class ShootAPI
    {
        public async Task<ApiProduct> GetDataFromApiAsync(string apiUrl, string apiKey)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<ApiProduct>>(jsonResponse);
                    return data.First();
                }
                else
                {
                    throw new Exception("Failed to get data from the API.");
                }
            }
        }
    }
}
