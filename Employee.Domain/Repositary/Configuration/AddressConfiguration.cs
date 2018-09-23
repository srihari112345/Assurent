using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Repositary.Configuration
{
    class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Map Table
            builder.ToTable("Address");

            //Primary Key
            builder.HasKey(x => x.AddressId);

            //Properties
            builder.Property(p => p.AddressId).HasColumnName("AddressId");
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.Line1).HasColumnName("Line1");
            builder.Property(p => p.Line2).HasColumnName("Line2");
            builder.Property(p => p.Line3).HasColumnName("Line3");
            builder.Property(p => p.City).HasColumnName("City");
            builder.Property(p => p.State).HasColumnName("State");
            builder.Property(p => p.Country).HasColumnName("Country");

            //Relationships
            builder.HasOne(p => p.Employee)
                   .WithMany(p => p.Addresses)
                   .HasForeignKey(p => p.EmployeeId);

        }
    }
}
