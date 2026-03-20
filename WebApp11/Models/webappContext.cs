using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp11.Models
{
    public partial class webappContext : IdentityDbContext
    {
        public webappContext()
        {
        }

        public webappContext(DbContextOptions<webappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emppss> Emppsses { get; set; } = null!;
        public virtual DbSet<AppUser> AppRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emppss>(entity =>
            {
                base.OnModelCreating(modelBuilder);
                entity.HasKey(e => e.Eid)
                    .HasName("PK__Emppss__C1971B53BD902D54");

                entity.ToTable("Emppss");

                entity.Property(e => e.Eid).ValueGeneratedNever();

                entity.Property(e => e.Ejob)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ejoin).HasColumnType("date");

                entity.Property(e => e.Ename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ename");

                entity.Property(e => e.Esalary).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
