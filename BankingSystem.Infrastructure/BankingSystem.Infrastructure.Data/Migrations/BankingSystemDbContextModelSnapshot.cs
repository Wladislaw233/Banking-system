﻿// <auto-generated />
using System;
using BankingSystem.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankingSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BankingSystemDbContext))]
    partial class BankingSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.AccountDb", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("account_id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("amount")
                        .HasColumnOrder(1);

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.ClientDb", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("client_id")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address")
                        .HasColumnOrder(8);

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age")
                        .HasColumnOrder(4);

                    b.Property<decimal>("Bonus")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("bonus")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth")
                        .HasColumnOrder(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email")
                        .HasColumnOrder(7);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("first_name")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("last_name")
                        .HasColumnOrder(2);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number")
                        .HasColumnOrder(6);

                    b.HasKey("ClientId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.CurrencyDb", b =>
                {
                    b.Property<Guid>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("currency_id")
                        .HasColumnOrder(0);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("code")
                        .HasColumnOrder(1);

                    b.Property<decimal>("ExchangeRate")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("exchange_rate")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.HasKey("CurrencyId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("currencies");
                });

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.EmployeeDb", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("employee_id")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("address")
                        .HasColumnOrder(8);

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age")
                        .HasColumnOrder(4);

                    b.Property<decimal>("Bonus")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("bonus")
                        .HasColumnOrder(5);

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contract")
                        .HasColumnOrder(9);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth")
                        .HasColumnOrder(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email")
                        .HasColumnOrder(7);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("first_name")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsOwner")
                        .HasColumnType("boolean")
                        .HasColumnName("is_owner")
                        .HasColumnOrder(11);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("last_name")
                        .HasColumnOrder(2);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number")
                        .HasColumnOrder(6);

                    b.Property<decimal>("Salary")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)")
                        .HasColumnName("salary")
                        .HasColumnOrder(10);

                    b.HasKey("EmployeeId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.AccountDb", b =>
                {
                    b.HasOne("BankingSystem.Infrastructure.Data.Models.ClientDb", "Client")
                        .WithMany("ClientAccounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Infrastructure.Data.Models.CurrencyDb", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("BankingSystem.Infrastructure.Data.Models.ClientDb", b =>
                {
                    b.Navigation("ClientAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
