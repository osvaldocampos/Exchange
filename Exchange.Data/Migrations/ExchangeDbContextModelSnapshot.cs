﻿// <auto-generated />
using System;
using Exchange.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Exchange.Data.Migrations
{
    [DbContext(typeof(ExchangeDbContext))]
    partial class ExchangeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Exchange.Data.Models.CurrencyType", b =>
                {
                    b.Property<int>("CurrencyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyTypeId");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            CurrencyTypeId = 1,
                            Name = "Dollar"
                        },
                        new
                        {
                            CurrencyTypeId = 2,
                            Name = "Real"
                        });
                });

            modelBuilder.Entity("Exchange.Data.Models.Limit", b =>
                {
                    b.Property<int>("LimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.HasKey("LimitId");

                    b.HasIndex("CurrencyTypeId")
                        .IsUnique();

                    b.ToTable("Limits");

                    b.HasData(
                        new
                        {
                            LimitId = 1,
                            Amount = 200m,
                            CurrencyTypeId = 1
                        },
                        new
                        {
                            LimitId = 2,
                            Amount = 300m,
                            CurrencyTypeId = 2
                        });
                });

            modelBuilder.Entity("Exchange.Data.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("CurrencyTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Exchange.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Jhon"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Terri"
                        });
                });

            modelBuilder.Entity("Exchange.Data.Models.UserTransaction", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<long>("TransactionId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "TransactionId");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("UserTransactions");
                });

            modelBuilder.Entity("Exchange.Data.Models.Limit", b =>
                {
                    b.HasOne("Exchange.Data.Models.CurrencyType", "CurrencyType")
                        .WithMany()
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("Exchange.Data.Models.Transaction", b =>
                {
                    b.HasOne("Exchange.Data.Models.CurrencyType", "CurrencyType")
                        .WithMany()
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyType");
                });

            modelBuilder.Entity("Exchange.Data.Models.UserTransaction", b =>
                {
                    b.HasOne("Exchange.Data.Models.Transaction", "Transaction")
                        .WithOne("UserTransaction")
                        .HasForeignKey("Exchange.Data.Models.UserTransaction", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exchange.Data.Models.User", "User")
                        .WithMany("UserTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Exchange.Data.Models.Transaction", b =>
                {
                    b.Navigation("UserTransaction");
                });

            modelBuilder.Entity("Exchange.Data.Models.User", b =>
                {
                    b.Navigation("UserTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
