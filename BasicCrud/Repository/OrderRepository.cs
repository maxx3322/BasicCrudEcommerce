using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Entities;
using BasicCrud.Data;
using BasicCrud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Repository
{
    
    public class OrderRepository : IOrderRepository
    {
        protected readonly AspnetRunContext _dbContext;

        public OrderRepository(AspnetRunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}

