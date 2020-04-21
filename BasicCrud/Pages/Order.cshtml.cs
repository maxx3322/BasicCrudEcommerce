using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BasicCrud.Entities;
using BasicCrud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud
{
    
        public class OrderModel : PageModel
        {
            private readonly IOrderRepository _orderRepository;

            public OrderModel(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            }

            public IEnumerable<Entities.Order> Orders { get; set; } = new List<Entities.Order>();

            public async Task<IActionResult> OnGetAsync()
            {
                Orders = await _orderRepository.GetOrdersByUserName("test");

                return Page();
            }
        }
    }
