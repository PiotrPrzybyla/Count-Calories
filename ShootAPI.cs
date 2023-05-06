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
    /// <summary>
    /// Klasa obsługująca zapytania do API.
    /// </summary>
    internal class ShootAPI
    {
        /// <summary>
        /// Metoda wysyłająca zapytanie do API.
        /// </summary>
        /// <param name="apiUrl">Adres url API.</param>
        /// <param name="apiKey">Klucz do API.</param>
        /// <returns>Model ApiProduct z API.</returns>
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
                    if (data.Count != 0) {
                        return data.First();
                    } return new ApiProduct();

                    
                }
                else
                {
                    throw new Exception("Failed to get data from the API.");
                }
            }
        }
    }
}
