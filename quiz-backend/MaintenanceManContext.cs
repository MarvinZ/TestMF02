using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quiz_backend.Models;
using MaintenanceBot;

namespace quiz_backend
{
    public class MaintenanceManContext : DbContext
    {
        public MaintenanceManContext(DbContextOptions<MaintenanceManContext> options) : base(options) { }

        public DbSet<WorkOrder> WorkOrders { get; set; }


    }
}
