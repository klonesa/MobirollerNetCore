using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mobiroller.Core.Entities.Concrete;
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

        public DbSet<User> Users { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
