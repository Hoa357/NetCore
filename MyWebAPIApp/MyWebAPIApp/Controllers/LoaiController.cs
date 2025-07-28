using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Data;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsloai = _context.Loais.ToList();
                return Ok(dsloai); // 200 
            }
           catch (Exception ex)
            {
                return BadRequest(new { Message = "Lỗi khi lấy danh sách loại: " + ex.Message });
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == (id));
            if(loai == null)
            {
                return NotFound(new { Message = "Loại không tồn tại." });
            }
            return Ok(loai);
        }



        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {

                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
               
                return StatusCode(201, new { Message = "Thêm loại thành công", Data = loai }); 
                           }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Lỗi khi thêm loại: " + ex.Message }); // 404
            }

        }



        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent(); // 204 
            }
            return Ok(loai);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == (id));
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
              
            }
            else
            {
                return NotFound(new { Message = "Loại không tồn tại." });
            }
          
        }


    }
}
