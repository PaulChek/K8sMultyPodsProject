using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api {
    public class CartModel {
        public CartModel(Guid id, List<Item> items) {
            Id = id;
            Items = items;
        }

        public Guid Id { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item {
        public Item(string name, int amount) {
            Name = name;
            Amount = amount;
        }

        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
