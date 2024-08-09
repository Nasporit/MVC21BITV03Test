using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EFCoreFirst.Models;

namespace EFCoreFirst.Models;

public partial class CarDealerContext : DbContext
{
    public CarDealerContext()
    {
    }

    public CarDealerContext(DbContextOptions<CarDealerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Nasporit;Database=CarDealer;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasKey(e => e.MaHh);

            entity.ToTable("HangHoa");

            entity.HasIndex(e => e.MaLoai, "IX_HangHoa_MaLoai");

            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.TenHh)
                .HasMaxLength(50)
                .HasColumnName("TenHH");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas).HasForeignKey(d => d.MaLoai);
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("Loai");

            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<EFCoreFirst.Models.Customer> Customer { get; set; } = default!;
}
