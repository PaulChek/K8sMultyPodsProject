using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cart.Api.Repository {
    public class CartRepo : IRepo {
        private string path;

        public CartRepo(IConfiguration configuration) {
            path = configuration.GetConnectionString("CartDb");
        }

        public Task<bool> AddItem(Guid id, Item item) {
            var carts = GetCarts();
          
            carts.FirstOrDefault(v => v.Id == id).Items.Add(item);
            
            File.WriteAllText(path, JsonSerializer.Serialize(carts));
            return Task.FromResult(true);
        }
        private List<CartModel> GetCarts() {
            try {
                var str = File.ReadAllText(path);
                var carts = JsonSerializer.Deserialize<List<CartModel>>(str);
                return carts ;
            }
            catch  {
                return new List<CartModel>();
            }
        }
        public Task<bool> CreateCart(Guid id) {
            var carts = GetCarts();
            carts.Add(new CartModel(id, new List<Item>()));
            var str = JsonSerializer.Serialize(carts);
            File.WriteAllText(path, str);
            return Task.FromResult(true);
        }

        public Task<CartModel> GetCart(Guid id) {
            return Task.FromResult(GetCarts().FirstOrDefault(v => v.Id == id));
        }
    }
}
