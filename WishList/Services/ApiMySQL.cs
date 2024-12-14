using System.Diagnostics;
using System.Text;
using System.Text.Json;
using WishList.Model;

namespace WishList.Services
{
    internal class ApiMySQL : IDataStore
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<Item>();
            }
        }

        // Bepaal het juiste URL op basis van platform en apparaat
        private string GetApiUrl()
        {
            // Controleer het platform
#if ANDROID
                return "http://10.0.2.2:8080/";
#elif WINDOWS
            return "http://localhost:8080/";
#else
            return "http://localhost:8080/";
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
            HttpClient client = new HttpClient();
            string apiUrl = GetApiUrl() + "api/item/" + item.Id;

            try
            {
                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(apiUrl, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting item: {ex.Message}");
            }
        }

        public async Task AddItem(Item item)
        {
            HttpClient client = new HttpClient();
            string apiUrl = GetApiUrl() + "api/item/";

            try
            {
                var itemToSend = new
                {
                    item.Naam,
                    item.Bedrag,
                    item.Beschrijving,
                    item.Bedrijf,
                    item.DatumToegevoegd
                };

                var json = JsonSerializer.Serialize(itemToSend);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);

                MessagingCenter.Send(this, "ItemAdded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding item: {ex.Message}");
            }
        }
    }
}
