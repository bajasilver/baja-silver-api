﻿using Baja.Silver.Domain.Catalog;
using Baja.Silver.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Baja.Silver.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
            { }

            public DbSet<Item> Items { get; set;}
            public DbSet<Order> Orders { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            { 
                base.OnModelCreating(builder);
                DbInitializer.Initialize(builder);
            }
    }
}