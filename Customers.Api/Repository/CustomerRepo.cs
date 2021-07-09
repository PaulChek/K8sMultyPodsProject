using Customers.Repository.Api;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using static Customers.Api.Model;
using System.Linq;

namespace Customers.Api.Repository {
    public class CustomerRepo : IRepository {
        private string PathToDb;

        public CustomerRepo(IConfiguration configuration) {
            PathToDb = configuration.GetConnectionString("Db");
        }

        public Task<bool> Add(Customer customer) {
            
            var all = GetCustomers();
            var temp = all.ToList();
            temp.Add(customer);
            var json = JsonSerializer.Serialize(temp);
            File.WriteAllText(PathToDb, json);
            return Task.FromResult(true);
        }

        public Task<Customer[]> GetAll() {
            var customers = GetCustomers();
            return Task.FromResult(customers);
        }

        private Customer[] GetCustomers() {
            try {
                return JsonSerializer.Deserialize<Customer[]>(File.ReadAllText(PathToDb));
            }
            catch {
                return   new Customer[0];
              }
            }
    }
}
