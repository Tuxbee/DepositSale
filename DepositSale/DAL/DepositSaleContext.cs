using System;
using System.Collections.Generic;
using System.Linq;
using DepositSale.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DepositSale.DAL
{
   public class DepositSaleContext : DbContext
   {
      public DepositSaleContext() : base("DepositSaleContext")
      {
         System.Diagnostics.Trace.WriteLine("test");
      }

      public DbSet<Provider> Providers { get; set; }
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Garment> Garments { get; set; }
      public DbSet<Other> Others { get; set; }
      public DbSet<JournalEvent> Events { get; set; }
      public DbSet<SaleEvent> SaleEvents { get; set; }
      public DbSet<RefundEvent> RefundEvents { get; set; }
      public DbSet<StockEvent> StockEvents { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      }

      public System.Data.Entity.DbSet<DepositSale.Models.Item> Items { get; set; }

      public System.Data.Entity.DbSet<DepositSale.Models.ItemDepositEvent> ItemDepositEvents { get; set; }

      public System.Data.Entity.DbSet<DepositSale.Models.ItemOffCallingEvent> ItemOffCallingEvents { get; set; }

      public System.Data.Entity.DbSet<DepositSale.Models.ItemRefundEvent> ItemRefundEvents { get; set; }

      public System.Data.Entity.DbSet<DepositSale.Models.ItemSaleEvent> ItemSaleEvents { get; set; }

      public System.Data.Entity.DbSet<DepositSale.Models.Contact> Contacts { get; set; }
   }
}