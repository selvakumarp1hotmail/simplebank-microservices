using System.Net.Http;

namespace SimpleBank.Gateway.Services
{
    public class CustomerServiceClient
    {
        private readonly HttpClient _httpClient;

        public CustomerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5074/api/customers");
            return await response.Content.ReadAsStringAsync();
        }
    }
}