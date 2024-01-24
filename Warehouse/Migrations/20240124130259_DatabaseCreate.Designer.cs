﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Warehouse.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240124130259_DatabaseCreate")]
    partial class DatabaseCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentWorker", b =>
                {
                    b.Property<Guid>("DepartmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("DepartmentWorker");
                });

            modelBuilder.Entity("Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DepartmentId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<Guid>("DepartnentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartnentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("WorkerId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("DepartmentWorker", b =>
                {
                    b.HasOne("Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Department", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DepartnentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Entities.Department", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
