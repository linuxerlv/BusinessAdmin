using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class StoreManagerContext : DbContext
    {
        public StoreManagerContext (DbContextOptions<StoreManagerContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.StoreManager> StoreManager { get; set; } = default!;
    }
}
