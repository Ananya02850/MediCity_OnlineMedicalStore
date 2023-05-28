using Microsoft.EntityFrameworkCore;
using MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, relationships, and constraints

            // Medicine entity
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicines");

                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Description).IsRequired().HasMaxLength(500);
                entity.Property(m => m.Price).HasColumnType("decimal(18,2)");
                entity.Property(m => m.Quantity).IsRequired();
                entity.Property(m => m.Manufacturer).HasMaxLength(100);
            });
        }
    }
}
