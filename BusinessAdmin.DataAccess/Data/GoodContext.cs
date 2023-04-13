using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class GoodContext : DbContext
    {
        public GoodContext (DbContextOptions<GoodContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.Good> Good { get; set; } = default!;
    }
}
