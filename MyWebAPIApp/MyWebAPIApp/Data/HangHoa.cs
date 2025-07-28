using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPIApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHangHoa { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public int SoLuong { get; set; } // Số lượng trong kho
        public byte GiamGia { get; set; } // Giảm giá theo phần trăm (0-100)

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }


        // Relationships
        // Relationships
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; } // Chi tiết đơn hàng


        public HangHoa()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}


