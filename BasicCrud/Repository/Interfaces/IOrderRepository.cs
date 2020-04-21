using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Entities;

namespace BasicCrud.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
