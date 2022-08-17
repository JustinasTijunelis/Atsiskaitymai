﻿// <auto-generated />
using InvoiceDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceDB.Migrations
{
    [DbContext(typeof(InvoiceDBContext))]
    partial class InvoiceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GuestOrder", b =>
                {
                    b.Property<string>("GuestsOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrdersOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GuestsOrderId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("GuestOrder");
                });

            modelBuilder.Entity("InvoiceDB.Entity.Guest", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<int>("Children")
                        .HasColumnType("int");

                    b.Property<string>("GuestCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("InvoiceDB.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AdultsAmount")
                        .HasColumnType("int");

                    b.Property<string>("CheckInDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckOutDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CityTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CleaningFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CleaningFeeTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GueasLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<string>("Property")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InvoiceDB.Tax", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<string>("CheckIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("GuestOrderId");

                    b.HasIndex("TaxOrderId");

                    b.ToTable("Taxs");
                });

            modelBuilder.Entity("OrderTax", b =>
                {
                    b.Property<string>("OrdersOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TaxsOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrdersOrderId", "TaxsOrderId");

                    b.HasIndex("TaxsOrderId");

                    b.ToTable("OrderTax");
                });

            modelBuilder.Entity("GuestOrder", b =>
                {
                    b.HasOne("InvoiceDB.Entity.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestsOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceDB.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvoiceDB.Tax", b =>
                {
                    b.HasOne("InvoiceDB.Entity.Guest", null)
                        .WithMany("Taxs")
                        .HasForeignKey("GuestOrderId");

                    b.HasOne("InvoiceDB.Tax", null)
                        .WithMany("Taxs")
                        .HasForeignKey("TaxOrderId");
                });

            modelBuilder.Entity("OrderTax", b =>
                {
                    b.HasOne("InvoiceDB.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceDB.Tax", null)
                        .WithMany()
                        .HasForeignKey("TaxsOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvoiceDB.Entity.Guest", b =>
                {
                    b.Navigation("Taxs");
                });

            modelBuilder.Entity("InvoiceDB.Tax", b =>
                {
                    b.Navigation("Taxs");
                });
#pragma warning restore 612, 618
        }
    }
}