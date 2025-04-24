using Microsoft.EntityFrameworkCore;
using Digify.Registration.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<CompanyApplicationModel> Companies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyApplicationModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.CompanyName).IsRequired();
                entity.Property(e => e.NPWP).IsRequired();
                entity.Property(e => e.DirectorName).IsRequired();
                entity.Property(e => e.PICName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.DocumentNPWPName).IsRequired();
                entity.Property(e => e.DocumentPowerOfAttorneyName).IsRequired();
                entity.Property(e => e.Deleted).IsRequired();
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.CreatedUserId);
                entity.Property(e => e.UpdatedDate);
                entity.Property(e => e.UpdatedUserId);
                entity.Property(e => e.DeletedDate);
                entity.Property(e => e.DeletedUserId);
                entity.HasIndex(o => o.Code).HasDatabaseName("IX_Company_Code").IsUnique();
            });
        }
    }
}
