﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop_FC_Summery.Models;

#nullable disable

namespace ShopFCSummery.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20230208184121_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop_FC_Summery.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "p1",
                            Price = 1m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "p2",
                            Price = 2m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "p3",
                            Price = 3m
                        });
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.ProductOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 3,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Login = "U1"
                        },
                        new
                        {
                            UserId = 2,
                            Login = "U2"
                        },
                        new
                        {
                            UserId = 3,
                            Login = "U3"
                        });
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.UserOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Created = new DateTime(2023, 2, 8, 20, 41, 21, 278, DateTimeKind.Local).AddTicks(3711),
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            Created = new DateTime(2023, 2, 8, 20, 41, 21, 278, DateTimeKind.Local).AddTicks(3759),
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 3,
                            Created = new DateTime(2023, 2, 8, 20, 41, 21, 278, DateTimeKind.Local).AddTicks(3762),
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 4,
                            Created = new DateTime(2023, 2, 8, 20, 41, 21, 278, DateTimeKind.Local).AddTicks(3765),
                            UserId = 2
                        },
                        new
                        {
                            OrderId = 5,
                            Created = new DateTime(2023, 2, 8, 20, 41, 21, 278, DateTimeKind.Local).AddTicks(3768),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.ProductOrder", b =>
                {
                    b.HasOne("Shop_FC_Summery.Models.UserOrder", "UserOrder")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop_FC_Summery.Models.Product", "Product")
                        .WithMany("ProductsOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("UserOrder");
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.UserOrder", b =>
                {
                    b.HasOne("Shop_FC_Summery.Models.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.Product", b =>
                {
                    b.Navigation("ProductsOrders");
                });

            modelBuilder.Entity("Shop_FC_Summery.Models.User", b =>
                {
                    b.Navigation("UserOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
