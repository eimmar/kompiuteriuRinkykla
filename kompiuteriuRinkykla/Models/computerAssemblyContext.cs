using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kompiuteriuRinkykla.Models
{
    public partial class computerAssemblyContext : DbContext
    {
        public computerAssemblyContext()
        {
        }

        public computerAssemblyContext(DbContextOptions<computerAssemblyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartType> PartType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=computerAssembly;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Qty).HasDefaultValueSql("((1))");
            });
        }
    }
}
