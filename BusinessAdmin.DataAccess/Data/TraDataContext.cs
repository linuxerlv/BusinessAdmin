using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class TraDataContext : DbContext
    {
        public TraDataContext (DbContextOptions<TraDataContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.TradeData> TradeData { get; set; } = default!;
    }
}
