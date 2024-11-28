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
                // Gebruik een platform-specifieke URL
                string apiUrl = GetApiUrl();
                apiUrl += "api/item/";

                string response = await client.GetStringAsync(apiUrl);

                
                return JsonSerializer.Deserialize<List<Item>>(response);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ApiMockData.cs");
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<Item>();
            }
        }

        // Bepaal het juiste URL op basis van platform en apparaat
        private string GetApiUrl()
        {
            // Controleer het platform
#if ANDROID
            if (IsEmulator())
            {
                return "http://10.0.2.2:5248/";
            }
            else
            {
                return "http://192.168.56.1:5248/";
            }
#elif WINDOWS
            return "http://localhost:5248/";
#else
            return "http://localhost:5248/";
#endif
        }

        private bool IsEmulator()
        {
#if ANDROID
            string model = Android.OS.Build.Model.ToLower();
            string device = Android.OS.Build.Device.ToLower();

            // Controleer de aanwezigheid van typische emulator-kenmerken
            return model.Contains("sdk") && device.Contains("emu");
#else
            return false;
#endif
        }
        public async Task DeleteItem(Item item)
        {
            HttpClient client = new HttpClient();
            string apiUrl = GetApiUrl() + "api/item/" + item.Id;

            try
            {
                var response = await client.DeleteAsync(apiUrl);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting item: {ex.Message}");
            }
        }

        public async Task UpdateItem(Item item)
        {
            Debug.WriteLine("===UpdateItem===");
            HttpClient client = new HttpClient();
            string apiUrl = GetApiUrl() + "api/item/" + item.Id;
            Debug.WriteLine("item.Id: " + item.Id);


            try
            {
                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(apiUrl, content);
                Debug.WriteLine($"response: {response}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting item: {ex.Message}");
            }
        }

        public async Task AddItem(Item item)
        {
            Debug.WriteLine("===AddItem===");
            HttpClient client = new HttpClient();
            string apiUrl = GetApiUrl() + "api/item/";

            try
            {
                var itemToSend = new
                {
                    item.Id,
                    item.Naam,
                    item.Bedrag,
                    item.Beschrijving,
                    item.Bedrijf
                };

                var json = JsonSerializer.Serialize(itemToSend);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Debug.WriteLine($"Sending POST request to: {apiUrl}");
                Debug.WriteLine($"Content: {json}");

                var response = await client.PostAsync(apiUrl, content);
                Debug.WriteLine($"response: {response}");

                var result = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response: {result}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding item: {ex.Message}");
            }   
        }
    }
}