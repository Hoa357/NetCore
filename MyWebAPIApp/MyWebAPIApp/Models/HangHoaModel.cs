namespace MyWebAPIApp.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }

    }

    public class HangHoaModel :  HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
      
    }

}
