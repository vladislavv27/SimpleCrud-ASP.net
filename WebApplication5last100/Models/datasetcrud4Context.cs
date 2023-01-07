using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication5last100.Models
{
    public partial class datasetcrud4Context : DbContext
    {
        public datasetcrud4Context()
        {
        }

        public datasetcrud4Context(DbContextOptions<datasetcrud4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseName> CourseNames { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseName>(entity =>
            {
                entity.ToTable("CourseName");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.CourseNameId, "IX_Student_CourseNameId");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseNameId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
