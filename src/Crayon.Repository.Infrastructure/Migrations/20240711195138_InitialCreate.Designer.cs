﻿// <auto-generated />
using System;
using Crayon.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crayon.Repository.Infrastructure.Migrations
{
    [DbContext(typeof(CrayonDbContext))]
    [Migration("20240711195138_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crayon.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Name = "User A-1"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            Name = "User A-2"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            Name = "User B-1"
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 3,
                            Name = "User C-1"
                        });
                });

            modelBuilder.Entity("Crayon.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Business A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Business B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Business C"
                        });
                });

            modelBuilder.Entity("Crayon.Domain.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("ValidUntilDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            CustomerId = 1,
                            ServiceId = new Guid("6cb82bcb-0f88-4708-bf3b-b926aa4d7027"),
                            ValidUntilDate = new DateOnly(2025, 7, 11)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 3,
                            ServiceId = new Guid("6cb82bcb-0f88-4708-bf3b-b926aa4d7027"),
                            ValidUntilDate = new DateOnly(2025, 7, 11)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
