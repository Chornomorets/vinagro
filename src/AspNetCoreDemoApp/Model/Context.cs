using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.AspNetCoreDemoApp;
using AspNetCoreDemoApp.Common;

namespace AspNetCoreDemoApp.Model
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public Context() { }
            
        public DbSet<Institute> Institute { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<MentorRequest> MentorRequest { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Student2Project> Student2Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(EnvironmentConfigManager.GetConnectionString());
    }
}