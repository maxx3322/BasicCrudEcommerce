using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Entities;

namespace BasicCrud.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ProductId  { get; set; }
        public Product Product { get; set; }
    }
}
