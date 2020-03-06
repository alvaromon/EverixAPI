using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class PrototypeDBContext : DbContext
    {
        public PrototypeDBContext()
        {
        }

        public PrototypeDBContext(DbContextOptions<PrototypeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PrototypeTable> PrototypeTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PrototypeDB;User ID=SA;Password=Oneshot1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrototypeTable>(entity =>
            {
                entity.HasKey(e => e.PrototypePk);

                entity.Property(e => e.PrototypePk)
                    .HasColumnName("PrototypePK")
                    .ValueGeneratedNever();

                entity.Property(e => e.OtherString)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrototypeString)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
