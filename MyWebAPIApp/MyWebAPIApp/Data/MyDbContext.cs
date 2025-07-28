using Microsoft.EntityFrameworkCore;

namespace MyWebAPIApp.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }

        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DonHang>(
                e => {
                    e.ToTable("DonHang");
                    e.HasKey(d => d.MaDh);
                    e.Property(d => d.NgayDat).HasDefaultValueSql("GETDATE()"); // Default value for NgayDat
                });


            modelBuilder.Entity<DonHangChiTiet>( e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(l => new {l.MaDh, l.MaHangHoa});
                e.HasOne(e => e.DonHang)
                    .WithMany(d => d.DonHangChiTiets)
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");


                e.HasOne(e => e.HangHoa)
                   .WithMany(d => d.DonHangChiTiets)
                   .HasForeignKey(e => e.MaHangHoa)
                   .HasConstraintName("FK_ChiTietDonHang_HangHoa");


            });

            modelBuilder.Entity<HangHoa>(
                e => {
                    e.ToTable("HangHoa");
                    e.HasKey(h => h.MaHangHoa);
                    e.HasOne(e => e.Loai)
                           .WithMany(d => d.HangHoas)
                           .HasForeignKey(e => e.MaLoai)
                           .HasConstraintName("FK_HangHoa_Loai");
                    e.Property(h => h.TenHangHoa).IsRequired().HasMaxLength(100);
                    e.Property(h => h.MoTa).IsRequired();
                    e.Property(h => h.SoLuong).IsRequired();
                    e.Property(h => h.DonGia).IsRequired();
                    e.Property(h => h.GiamGia).HasDefaultValue(0);

                });


             modelBuilder.Entity<Loai>(
                e => {
                    e.ToTable("Loai");
                    e.HasKey(l => l.MaLoai);
                    e.Property(l => l.TenLoai).IsRequired().HasMaxLength(100);
                });


        }
    }

}
