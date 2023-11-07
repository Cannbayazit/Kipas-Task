using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(20).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Gender).IsRequired();
            builder.Property(e => e.BirthDate).IsRequired();
            builder.Property(e => e.HireDate).HasDefaultValueSql("getdate()");
            builder.HasOne(e => e.EmployeeAddress).WithOne(e => e.Employee).HasForeignKey<EmployeeAddress>(e => e.EmployeeID);
        }
    }

}