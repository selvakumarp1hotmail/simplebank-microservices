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
            return await _httpClient.GetStringAsync("http://localhost:5166/api/transactions");
        }
    }
}