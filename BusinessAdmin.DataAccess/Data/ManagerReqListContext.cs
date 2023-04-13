using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Data
{
    public class ManagerReqListContext : DbContext
    {
        public ManagerReqListContext (DbContextOptions<ManagerReqListContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessAdmin.DataAccess.Models.ManagerReqList> ManagerReqList { get; set; } = default!;
    }
}
