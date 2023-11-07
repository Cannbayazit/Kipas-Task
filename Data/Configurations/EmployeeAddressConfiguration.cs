using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).ValueGeneratedOnAdd();
            builder.Property(e => e.Address).HasMaxLength(200).IsRequired();
            builder.HasOne(e => e.Employee).WithOne(e => e.EmployeeAddress).HasForeignKey<Employee>(e => e.EmployeeAddressID);
            builder.HasOne(e => e.State).WithMany(e => e.EmployeeAddressList).HasForeignKey(e => e.StateID);
        }
    }
}