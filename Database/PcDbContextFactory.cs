using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace PersonalClassroom.Database
{
    public class PcDbContextFactory : IDesignTimeDbContextFactory<PcContext>
    {
        public PcContext CreateDbContext(string[] args)
        {
            return new PcContext(new DbContextOptionsBuilder<PcContext>()
              .UseNpgsql("Username=admin;Password=admin;Server=localhost:5432;Database=personal_classroom")
              .Options);
        }
    }
}
