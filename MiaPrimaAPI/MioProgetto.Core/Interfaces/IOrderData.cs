using MioProgetto.Core.Entities;
using MioProgetto.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MioProgetto.Core.Interfaces
{
    public interface IOrderData
    {
        List<OrderViewModel> GetOrders();
        OrderViewModel GetOrderById(int id);
        void AddOrder(Order newOrder);
        void UpdateOrder(Order modifiedOrder);
        void DeleteOrder(int id);
    }
}
