using Microsoft.AspNetCore.Mvc;
using SimpleBank.Gateway.Services;
using SimpleBank.Gateway.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;



namespace SimpleBank.Gateway.Controllers
{
    [ApiController]
    [Route("api/gateway")]
    public class GatewayController : ControllerBase
    {
        private readonly CustomerServiceClient _customerService;
        private readonly AccountServiceClient _accountService;
        private readonly TransactionServiceClient _transactionService;

        public GatewayController(CustomerServiceClient customerService, AccountServiceClient accountService, TransactionServiceClient transactionService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("Gateway is running");
        }

        /*[HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);
        }*/



        [Authorize]

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomersAsync();

            var customers = JsonSerializer.Deserialize<List<CustomerDto>>(
                result,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return Ok(customers);
        }

        /*[HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var result = await _accountService.GetAccountsAsync();
            return Ok(result);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await _transactionService.GetTransactionsAsync();
            return Ok(result);
        }*/
      

[HttpGet("accounts")]
    public async Task<IActionResult> GetAccounts()
    {
        var result = await _accountService.GetAccountsAsync();

        var accounts = JsonSerializer.Deserialize<List<object>>(
            result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return Ok(accounts);
    }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await _transactionService.GetTransactionsAsync();

            var transactions = JsonSerializer.Deserialize<List<object>>(
                result,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return Ok(transactions);
        }

    }
}