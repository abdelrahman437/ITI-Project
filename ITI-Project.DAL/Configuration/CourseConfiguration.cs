using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.DAL.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasOne(c => c.Instructor)
                .WithMany(u => u.CoursesTaught)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
