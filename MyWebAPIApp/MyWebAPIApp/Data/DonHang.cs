namespace MyWebAPIApp.Data
{

    public enum TinhTrangDonDatHang
    {
        ChuaDat, // Chưa đặt hàng
        DaDat, // Đã đặt hàng
        DangGiao, // Đang giao hàng
        DaGiao, // Đã giao hàng
        HuyDon // Đã hủy đơn hàng
    }
    public class DonHang
    {
        public Guid MaDh { get; set; } // Mã đơn hàng
        public DateTime NgayDat { get; set; } // Ngày đặt hàng
        public DateTime? NgayGiao { get; set; } // Ngày giao hàng (có thể null nếu chưa giao)

        public TinhTrangDonDatHang TinhTrang { get; set; } // Tình trạng đơn hàng

        public string NguoiNhan { get; set; } // Người nhận hàng
        public string DiaChiGiao { get; set; } // Địa chỉ giao hàng
        public string SoDienThoai { get; set; } // Số điện thoại người nhận

        // Relationships
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; } // Chi tiết đơn hàng


        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}
