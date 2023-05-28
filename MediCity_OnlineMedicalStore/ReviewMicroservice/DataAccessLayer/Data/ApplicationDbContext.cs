using Microsoft.EntityFrameworkCore;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Models;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Review entity
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Review>()
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Review>()
                .Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Medicine)
                .WithMany()
                .HasForeignKey(r => r.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
