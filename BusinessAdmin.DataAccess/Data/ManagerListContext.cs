using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class ManagerListContext : DbContext
    {
        public ManagerListContext (DbContextOptions<ManagerListContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.ManagerList> ManagerList { get; set; } = default!;
    }
}
