using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Repositary.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Model.Employee>
    {
        public void Configure(EntityTypeBuilder<Model.Employee> builder)
        {
            //Map Table
            builder.ToTable("Employee");

            //Primary Key
            builder.HasKey(x => x.EmployeeId);

            //Property
            builder.Property(x => x.EmployeeId).HasColumnName("EmployeeId").UseSqlServerIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.BaseLocation).HasColumnName("BaseLocation").HasMaxLength(20);
        }
    }
}
