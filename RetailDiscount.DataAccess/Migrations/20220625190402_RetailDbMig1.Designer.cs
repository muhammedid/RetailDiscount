﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetailDiscount.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace RetailDiscount.DataAccess.Migrations
{
    [DbContext(typeof(RetailContext))]
    [Migration("20220625190402_RetailDbMig1")]
    partial class RetailDbMig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CutomerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountTotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InvoiceTotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PayableAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.InvoiceDiscount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("InvoiceDiscounts");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.InvoiceLine", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineID"), 1L, 1);

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LineID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ProductID");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.Invoice", b =>
                {
                    b.HasOne("RetailDiscount.Entities.Concrete.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.InvoiceDiscount", b =>
                {
                    b.HasOne("RetailDiscount.Entities.Concrete.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.InvoiceLine", b =>
                {
                    b.HasOne("RetailDiscount.Entities.Concrete.Invoice", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailDiscount.Entities.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RetailDiscount.Entities.Concrete.Invoice", b =>
                {
                    b.Navigation("InvoiceLines");
                });
#pragma warning restore 612, 618
        }
    }
}