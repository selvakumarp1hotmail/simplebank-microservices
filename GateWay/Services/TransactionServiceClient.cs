using System.Net.Http.Json;

namespace SimpleBank.Gateway.Services
{
    public class TransactionServiceClient
    {
        private readonly HttpClient _httpClient;



        public TransactionServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetTransactionsAsync()
{
    var response = await _httpClient.GetAsync("http://transaction-api/api/transactions");

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
}

/*public async Task<string> GetTransactionsAsync()
{
    var response = await _httpClient.GetAsync("http://transaction-api/api/transactions");

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
}*/



public async Task<string> CreateTransactionAsync(object data)
{
    var response = await _httpClient.PostAsJsonAsync(
        "http://transaction-api/api/transactions", data);

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
}


        /*public async Task<string> GetTransactionsAsync()
        {
            return await _httpClient.GetAsync("http://transaction-api/api/transactions");
            //return await _httpClient.GetStringAsync("http://localhost:5166/api/transactions");
        }*/
    }
}