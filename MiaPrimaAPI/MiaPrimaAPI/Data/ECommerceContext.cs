using Microsoft.EntityFrameworkCore;
using MioProgetto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiaPrimaAPI.Data
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> opzioni): base(opzioni)
        {}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
