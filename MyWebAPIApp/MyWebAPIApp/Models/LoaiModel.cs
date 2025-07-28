using System.ComponentModel.DataAnnotations;

namespace MyWebAPIApp.Models
{
    public class LoaiModel
    {
        
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }

    }
}
