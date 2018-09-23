using Microsoft.EntityFrameworkCore;
using Employee.Domain.Model;
using System;
using Employee.Domain.Repositary.Configuration;

namespace Employee.Domain
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Model.Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEngagement> ProjectEngagements { get; set; }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEngagementConfiguration());
        }


    }
}
