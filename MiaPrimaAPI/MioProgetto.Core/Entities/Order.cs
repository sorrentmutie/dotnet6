using System;
using System.Collections.Generic;

namespace MioProgetto.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int ClientId {get;set;}
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
