using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemoApp.Model
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public Context() { }
            
        public DbSet<Institute> Institutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new PostgreSqlConnectionStringBuilder("postgres://idjwltepabhcst:1b36a53486fd99f4549577a743a0a25292089b5b88b22c6505a23d97b4e394b2@ec2-79-125-4-96.eu-west-1.compute.amazonaws.com:5432/de0ehmmkkm4sns")
            {
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Require
            };

            optionsBuilder.UseNpgsql(builder.ToString());
        }
    }
}
