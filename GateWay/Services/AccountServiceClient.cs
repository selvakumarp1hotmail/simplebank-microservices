namespace SimpleBank.Gateway.Services
{
    public class AccountServiceClient
    {
        private readonly HttpClient _httpClient;

        public AccountServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

public async Task<string> GetAccountsAsync()
{
    var response = await _httpClient.GetAsync("http://account-api/api/accounts");

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
}


/*public async Task<string> GetAccountsAsync()
{
    var response = await _httpClient.GetAsync("http://account-api/api/accounts");

    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync();
}*/
        /*public async Task<string> GetAccountsAsync()
        {
            return await _httpClient.GetAsync("http://account-api/api/accounts");
            //return await _httpClient.GetStringAsync("http://localhost:5172/api/accounts");
        }*/
    }
}