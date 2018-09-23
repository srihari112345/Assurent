using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Repositary.Configuration
{
    class ProjectEngagementConfiguration : IEntityTypeConfiguration<ProjectEngagement>
    {
        public void Configure(EntityTypeBuilder<ProjectEngagement> builder)
        {
            //Map Table
            builder.ToTable("ProjectEngagement");

            //Primary Key
            builder.HasKey(k => k.EngagementId);

            //Properties
            builder.Property(p => p.EngagementId).HasColumnName("EngagementId");
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId");

            //Relationships
            builder.HasOne(p => p.Project)
                   .WithMany(p => p.ProjectEngagements)
                   .HasForeignKey(p => p.ProjectId);

            builder.HasOne(p => p.Employee)
                   .WithMany(p => p.ProjectEngagements)
                   .HasForeignKey(p => p.EmployeeId);
        }
    }
}
