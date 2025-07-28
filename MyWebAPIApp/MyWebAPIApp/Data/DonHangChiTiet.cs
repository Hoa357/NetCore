namespace MyWebAPIApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHangHoa { get; set; }
        public Guid MaDh { get; set; } // Mã đơn hàng

        public int SoLuong { get; set; } // Số lượng hàng hóa trong đơn hàng

        public double DonGia { get; set; } // Đơn giá hàng hóa tại thời điểm đặt hàng

        public byte GiamGia { get; set; } // Giảm giá theo phần trăm (0-100)


        // Relationships

        public DonHang DonHang { get; set; } // Tham chiếu đến đơn hàng cha (nếu có)
    
        public HangHoa HangHoa { get; set; } // Tham chiếu đến hàng hóa trong đơn hàng



    }
}
