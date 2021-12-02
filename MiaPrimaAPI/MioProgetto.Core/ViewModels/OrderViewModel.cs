using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Range(1, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ClientId { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
        [Required]
        public string Esempio { get; set; }
    }
}
