using Cart.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cart.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase {
        private readonly IRepo _cartrepo;

        public CartController(IRepo cartrepo) {
            _cartrepo = cartrepo;
        }
        
        [HttpGet]
        public async Task<ActionResult<CartModel>> Get(Guid id) {
            return await _cartrepo.GetCart(id);
        }
      
        [HttpPost]
        public async Task<ActionResult<bool>> PostCreateCart(Guid id) {
            return await _cartrepo.CreateCart(id);
        }
        [HttpPost("{id}", Name = "AddItem")]
        public async Task<ActionResult<bool>> PostAddItem(Guid id, [FromBody] Item item) {
            return await _cartrepo.AddItem(id, item);
        }
    }
}
