﻿// <auto-generated />
using Employee.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.Domain.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20180921125428_initialisingdb")]
    partial class initialisingdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employee.Domain.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .HasColumnName("Country");

                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeId");

                    b.Property<string>("Line1")
                        .HasColumnName("Line1");

                    b.Property<string>("Line2")
                        .HasColumnName("Line2");

                    b.Property<string>("Line3")
                        .HasColumnName("Line3");

                    b.Property<string>("State")
                        .HasColumnName("State");

                    b.HasKey("AddressId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Employee.Domain.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaseLocation")
                        .HasColumnName("BaseLocation")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employee.Domain.Model.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProjectId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Employee.Domain.Model.ProjectEngagement", b =>
                {
                    b.Property<int>("EngagementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EngagementId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectId");

                    b.HasKey("EngagementId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectEngagement");
                });

            modelBuilder.Entity("Employee.Domain.Model.Address", b =>
                {
                    b.HasOne("Employee.Domain.Model.Employee", "Employee")
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Employee.Domain.Model.ProjectEngagement", b =>
                {
                    b.HasOne("Employee.Domain.Model.Employee", "Employee")
                        .WithMany("ProjectEngagements")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Employee.Domain.Model.Project", "Project")
                        .WithMany("ProjectEngagements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
