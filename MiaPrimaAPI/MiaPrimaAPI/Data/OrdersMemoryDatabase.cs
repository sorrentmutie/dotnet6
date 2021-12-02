using Microsoft.EntityFrameworkCore;
using MioProgetto.Core.Entities;
using MioProgetto.Core.Interfaces;
using MioProgetto.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiaPrimaAPI.Data
{
    public class OrdersMemoryDatabase : IOrderData
    {
        private readonly ECommerceContext database;

        public OrdersMemoryDatabase(ECommerceContext database)
        {
            this.database = database;

            if (database.Orders.Count() == 0)
            {
                database.Orders.Add(new Order { Date = DateTime.Today, ClientId = 1, Total = 100.0M });
                database.Orders.Add(new Order { Date = DateTime.Today, ClientId = 1, Total = 200.0M });
                database.SaveChanges();
            }

        }
        public void AddOrder(Order newOrder)
        {
            database.Orders.Add(newOrder);
            database.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var orderInDb = GetOrderById(id);
            database.Entry(orderInDb).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            database.SaveChanges();

        }

        public OrderViewModel GetOrderById(int id)
        {
            // return database.Orders.FirstOrDefault( order => order.Id == id);
            var order = database.Orders.Find(id);
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                Date = order.Date,
                Total = order.Total,
                Items = (order.Items.Select(item =>
                new OrderItemViewModel
                {
                    Id = item.Id,
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                })).ToList()
            };
        }

        public List<OrderViewModel> GetOrders()
        {
            return database.Orders.Include(o => o.Items)
                .Select(order => new OrderViewModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    Date = order.Date,
                    Total = order.Total,
                    Items = (order.Items.Select(item =>
new OrderItemViewModel
{
  Id = item.Id,
  OrderId = order.Id,
  ProductId = item.ProductId,
  Quantity = item.Quantity,
  UnitPrice = item.UnitPrice
})).ToList()
                })
                .ToList();
        }

        public void UpdateOrder(Order modifiedOrder)
        {
            var orderInDb = GetOrderById(modifiedOrder.Id);
            database.Entry(orderInDb).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            database.Entry(modifiedOrder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            database.SaveChanges();
        }
    }
}
