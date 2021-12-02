using MioProgetto.Core.Entities;
using MioProgetto.Core.Interfaces;
using MioProgetto.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MioProgetto.Core.Implementations
{
    public class OrdersStaticData : IOrderData
    {
        public void AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> GetOrders()
        {
            var orders = new List<OrderViewModel>();
            orders.Add(new OrderViewModel { Id = 1, ClientId = 1, Total = 50.0M, Date = DateTime.Today });
            orders.Add(new OrderViewModel { Id = 2, ClientId = 1, Total = 150.0M, Date = DateTime.Today.AddDays(-7) });
            return orders;
        }

        public void UpdateOrder(Order modifiedOrder)
        {
            throw new NotImplementedException();
        }
    }
}
