using AppData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        AppDbContext _context = new AppDbContext();
        // GET: api/<NhanvienController>
        [HttpGet("get-all")]
        public ActionResult Get()
        {
            return Ok(_context.Nhanviens.ToList());
        }

        // GET api/<NhanvienController>/5
        [HttpGet("get-by-id")]
        public ActionResult Get(Guid id)
        {
            return Ok(_context.Nhanviens.Find(id));
        }

        // POST api/<NhanvienController>
        [HttpPost("tao-nhanvien")]
        public ActionResult Post(Nhanvien nv)
        {
            try
            {
                _context.Nhanviens.Add(nv); _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // PUT api/<NhanvienController>/5
        [HttpPut("sua-nhanvien")]
        public ActionResult Put(Nhanvien nv)
        {
            try
            {
                var updateItem = _context.Nhanviens.Find(nv.Id); 
                updateItem.Ten = nv.Ten; // CÒn nhiều cái nhưng sửa mỗi tên thôi
                _context.Nhanviens.Update(updateItem);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<NhanvienController>/5
        [HttpDelete("xoa-by-id")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var deleteItem = _context.Nhanviens.Find(id);
                _context.Nhanviens.Remove(deleteItem);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
