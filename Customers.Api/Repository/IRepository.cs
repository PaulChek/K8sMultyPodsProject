using System.Threading.Tasks;
using static Customers.Api.Model;

namespace Customers.Repository.Api {
    public interface IRepository {
        Task<bool> Add(Customer customer);
        Task<Customer[]> GetAll();
    }
}
