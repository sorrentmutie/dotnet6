using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MioProgetto.Core.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();

    }
}
