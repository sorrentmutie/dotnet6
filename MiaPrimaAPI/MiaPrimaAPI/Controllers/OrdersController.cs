using Microsoft.AspNetCore.Mvc;
using MioProgetto.Core.Entities;
using MioProgetto.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MiaPrimaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderData ordersData;

        public OrdersController(IOrderData ordersData)
        {
            this.ordersData = ordersData;
        }

        [HttpGet]
        [Produces(typeof(List<Order>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(ordersData.GetOrders());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(Order))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = ordersData.GetOrderById(id);
                if (order == null) return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message); ;
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order == null || order !=null && order.ClientId == 0) return BadRequest();
                ordersData.AddOrder(order);
                return StatusCode(201, "Order was created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult UpdateOrder([FromBody] Order order, int id)
        {
            try
            {
                if (order == null || order.Id != id) return BadRequest();
                var orderDb = ordersData.GetOrderById(id);
                if (orderDb == null) return NotFound();
                ordersData.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                if (id <= 0) return BadRequest(); 

                var orderDb = ordersData.GetOrderById(id);
                if (orderDb == null) return NotFound();

                ordersData.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
