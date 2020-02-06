using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Order
            {
                Date = DateTime.Now.AddDays(index),
                OrderNumber = rng.Next(1, 500)
            })

            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return new Order { Date = DateTime.Now, OrderNumber = 12345 };
        }
    }
}
