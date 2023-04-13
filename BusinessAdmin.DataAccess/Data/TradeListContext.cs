using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class TradeListContext : DbContext
    {
        public TradeListContext (DbContextOptions<TradeListContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.TradeList> TradeList { get; set; } = default!;
    }
}
