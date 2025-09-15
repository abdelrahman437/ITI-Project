using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.DAL.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder
                  .HasOne(s => s.Course)
                  .WithMany(c => c.Sessions)
                  .HasForeignKey(s => s.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
