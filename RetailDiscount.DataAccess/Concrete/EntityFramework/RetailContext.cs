using Microsoft.EntityFrameworkCore;
using RetailDiscount.Entities.Concrete;
using RetailDiscount.Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscount.DataAccess.Concrete.EntityFramework
{
    public class RetailContext:DbContext
    {
        public RetailContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Retail;Trusted_Connection=true");
        }
        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceDiscount> InvoiceDiscounts { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .Property(e => e.CustomerType)
                .HasConversion(
                    v => v.ToString(),
                    v => (CustomerTypeEnum)Enum.Parse(typeof(CustomerTypeEnum), v));

            modelBuilder
             .Entity<InvoiceDiscount>()
             .Property(e => e.DiscountType)
             .HasConversion(
                 v => v.ToString(),
                 v => (DiscountTypeEnum)Enum.Parse(typeof(DiscountTypeEnum), v));
        }
    }
}
