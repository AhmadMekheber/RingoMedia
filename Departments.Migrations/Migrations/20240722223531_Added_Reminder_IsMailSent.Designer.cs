﻿// <auto-generated />
using System;
using Departments.Migrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Departments.Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240722223531_Added_Reminder_IsMailSent")]
    partial class Added_Reminder_IsMailSent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Departments.Model.Department", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("ParentDepartmentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ParentDepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Departments.Model.Reminder", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMailSent")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RemindingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Departments.Model.Department", b =>
                {
                    b.HasOne("Departments.Model.Department", "ParentDepartment")
                        .WithMany("SubDepartments")
                        .HasForeignKey("ParentDepartmentID");

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("Departments.Model.Department", b =>
                {
                    b.Navigation("SubDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}
