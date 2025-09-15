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
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
           builder
                .HasOne(g => g.Session)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                 .HasOne(g => g.Trainee)
                 .WithMany(u => u.Grades)
                 .HasForeignKey(g => g.TraineeId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
