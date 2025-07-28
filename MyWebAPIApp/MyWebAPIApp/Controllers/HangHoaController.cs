using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoaModel> hangHoas = new List<HangHoaModel>();

        [HttpGet] // Lấy danh sách hàng hoá
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [OBject] Query
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }


        }


        [HttpPost] // Thêm mới hàng hoá

        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoaModel
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa,
            });
        }



        [HttpPut("{id}")] // Sửa mới hàng hoá

        public IActionResult Edit(string id, HangHoaModel hangHoaEdit)
        {
            try
            {
                // LINQ [OBject] Query
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                //
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Updates
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                {
                    if (hanghoa == null)
                    {
                        return NotFound();
                    }


                    hangHoas.Remove(hanghoa);
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();

            }
        }
        

    }
}
