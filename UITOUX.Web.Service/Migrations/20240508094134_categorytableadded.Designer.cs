﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UITOUX.Web.Service.DBConfiguration;

#nullable disable

namespace UITOUX.Web.Service.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240508094134_categorytableadded")]
    partial class categorytableadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("UITOUX.Web.Service.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("UITOUX.Web.Service.Models.Currency", b =>
                {
                    b.Property<long>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISOCode")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CurrencyId");

                    b.ToTable("currencies");
                });

            modelBuilder.Entity("UITOUX.Web.Service.Models.Language", b =>
                {
                    b.Property<long>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISOCode")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("LanguageId");

                    b.ToTable("languages");
                });
#pragma warning restore 612, 618
        }
    }
}
