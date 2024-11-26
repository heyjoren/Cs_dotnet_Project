using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Model;
using System.Net.Http;
using System.Text.Json;
using System.Diagnostics;

namespace WishList.Services
{
    internal class ApiMockData : IDataStore
    {
        public static List<Item> ItemsList = new List<Item>();

        public async Task<List<Item>> GetAllItems()
        {
            HttpClient client = new HttpClient();
            try
            {
                string responseLocalHost = await client.GetStringAsync("http://localhost:5248/api/item/");

                Debug.WriteLine("responseLocalHost");
                Debug.WriteLine(responseLocalHost);
                Debug.WriteLine("JsonSerializer.Deserialize<List<Item>>(responseLocalHost)");
                Debug.WriteLine(JsonSerializer.Deserialize<List<Item>>(responseLocalHost));

                return JsonSerializer.Deserialize<List<Item>>(responseLocalHost);
            }
            catch
            {
                string response = await client.GetStringAsync("http://10.0.2.2:5248/api/item/");

                Debug.WriteLine("response");
                Debug.WriteLine(response);
                Debug.WriteLine("JsonSerializer.Deserialize<List<Item>>(response)");
                Debug.WriteLine(JsonSerializer.Deserialize<List<Item>>(response));

                return JsonSerializer.Deserialize<List<Item>>(response);

            }
        }
    }

}
