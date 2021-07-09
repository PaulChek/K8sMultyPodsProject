using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customers.Api.Services {
    public class CartService : ICartService {
        private readonly HttpClient _cartClient;

        public CartService(IConfiguration configuration, HttpClient cartClient) {
            _cartClient = cartClient;
            _cartClient.BaseAddress = new Uri(configuration.GetConnectionString("CartHost"));
        }

        public async Task<bool> CreateCart(Guid id) {
            var res = await _cartClient.PostAsync($"api/Cart?id={id}", null);
            return res.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
