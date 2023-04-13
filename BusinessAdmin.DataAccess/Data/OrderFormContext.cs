using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class OrderFormContext : DbContext
    {
        public OrderFormContext (DbContextOptions<OrderFormContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.OrderForm> OrderForm { get; set; } = default!;
    }
}
