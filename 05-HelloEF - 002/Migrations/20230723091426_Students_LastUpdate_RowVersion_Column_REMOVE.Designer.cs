﻿// <auto-generated />
using System;
using HelloEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelloEF.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230723091426_Students_LastUpdate_RowVersion_Column_REMOVE")]
    partial class Students_LastUpdate_RowVersion_Column_REMOVE
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HelloEF.DomainModels.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("HelloEF.DomainModels.ProjectStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectStudent");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<decimal>("AverageSalary")
                        .HasColumnType("decimal(16,2)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Surname");

                    b.Property<int>("LevelOfExpertise")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("HelloEF.DomainModels.ProjectStudent", b =>
                {
                    b.HasOne("HelloEF.DomainModels.Project", "Project")
                        .WithMany("ProjectStudents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloEF.DomainModels.Student", "Student")
                        .WithMany("ProjectStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Student", b =>
                {
                    b.HasOne("HelloEF.DomainModels.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Students_Departments");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Project", b =>
                {
                    b.Navigation("ProjectStudents");
                });

            modelBuilder.Entity("HelloEF.DomainModels.Student", b =>
                {
                    b.Navigation("ProjectStudents");
                });
#pragma warning restore 612, 618
        }
    }
}