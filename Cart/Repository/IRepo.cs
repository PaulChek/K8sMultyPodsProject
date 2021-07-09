using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Repository {
   public interface IRepo {
        Task<bool> CreateCart(Guid id);
        Task<CartModel> GetCart(Guid id);
        Task<bool> AddItem(Guid id, Item item);
    }
}
