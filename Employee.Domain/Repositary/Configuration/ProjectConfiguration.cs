using Employee.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Repositary.Configuration
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            //Map Table
            builder.ToTable("Project");

            //Primary Key
            builder.HasKey(k => k.ProjectId);

            //Properties
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId");
            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}
