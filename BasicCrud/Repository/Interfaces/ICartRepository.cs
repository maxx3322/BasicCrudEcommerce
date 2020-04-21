using BasicCrud.Data;
using BasicCrud.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicCrud.Repository.Interfaces
{
    public interface ICartRepository
        {
            Task<Cart> GetCartByUserName(string userName);
            Task AddItem(string userName, int productId, int quantity = 1, string color = "Black");
            Task RemoveItem(int cartId, int cartItemId);
            Task ClearCart(string userName);
        }
    }
