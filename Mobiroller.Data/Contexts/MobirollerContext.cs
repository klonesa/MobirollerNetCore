using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mobiroller.Entities.Concrete;

namespace Mobiroller.Data.Contexts
{
    public class MobirollerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Mobiroller;integrated security=true;");
        }

        public DbSet<EventTr> EventsTr { get; set; }
        public DbSet<EventIt> EventsIt { get; set; }
    }
}
