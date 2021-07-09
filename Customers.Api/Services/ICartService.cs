using System;
using System.Threading.Tasks;

namespace Customers.Api.Services {
    public interface ICartService {
        Task<bool> CreateCart(Guid id);
    }
}
