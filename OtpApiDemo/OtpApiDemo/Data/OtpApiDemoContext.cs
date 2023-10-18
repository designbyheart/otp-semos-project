using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OtpApiDemo.Models;

namespace OtpApiDemo.Data
{
    public class OtpApiDemoContext : DbContext
    {
        public OtpApiDemoContext (DbContextOptions<OtpApiDemoContext> options)
            : base(options)
        {
        }

        public DbSet<OtpApiDemo.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public DbSet<OtpApiDemo.Models.Account> Account { get; set; } = default!;
    }
}
