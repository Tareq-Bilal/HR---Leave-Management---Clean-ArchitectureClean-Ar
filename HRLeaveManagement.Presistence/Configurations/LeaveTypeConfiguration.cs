using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Presistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    Name = "Moahmmed",
                    DefaultDays = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
                );


            builder.Property(q => q.Name)
                   .IsRequired()
                   .HasMaxLength(100);

        }
    }
}
