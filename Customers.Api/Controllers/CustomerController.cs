using Customers.Api.Services;
using Customers.Repository.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Customers.Api.Model;

namespace Customers.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        private readonly IRepository _customerRepo;
        private readonly ICartService _cartService;

        public CustomerController(IRepository customerRepo, ICartService cartService) {
            _customerRepo = customerRepo;
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add(Customer customer) {
            customer.Id = Guid.NewGuid();
            _ = _cartService.CreateCart(customer.Id);
            return await _customerRepo.Add(customer);
        }
        [HttpGet]
        public async Task<ActionResult<Customer[]>> Get() {
            return await _customerRepo.GetAll();
        }
    }
}
