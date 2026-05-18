using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL.Models
{
    public class EduManagerDbContext 
        : DbContext
    {
        public EduManagerDbContext() { }

        public EduManagerDbContext(
            DbContextOptions<EduManagerDbContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string strConn = "Server=.\\SQLEXPRESS;" +
                    "Database=EduManagerDb;User Id=sa;" +
                    "Password=1;Trusted_Connection=True;" +
                    "TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(strConn);
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId)
                        .ValueGeneratedOnAdd();
                entity.Property(e => e.StudentCode)
                        .IsRequired()
                        .HasMaxLength(10);
                entity.HasIndex(e => e.StudentCode)
                        .IsUnique();
                entity.Property(e => e.FullName)
                        .IsRequired()
                        .HasMaxLength(100);
                entity.Property(e => e.DateOfBirth)
                        .HasColumnType("date");
                entity.Property(e => e.Gender)
                        .IsRequired()
                        .HasMaxLength(10);
                entity.Property(e => e.Email)
                        .HasMaxLength(100);
                entity.Property(e => e.Phone)
                        .HasMaxLength(10);
                entity.Property(e => e.Major)
                        .HasMaxLength(100);
                entity.Property(e => e.IsActive)
                        .HasDefaultValue(true);
            });
        }
    }
}
