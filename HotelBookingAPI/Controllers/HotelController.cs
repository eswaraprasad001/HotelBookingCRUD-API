using HotelBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelDBContext _context;

        public HotelController(HotelDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<ActionResult<List<Hotel>>> Index()
        {
            return Ok(_context.Hotels.ToList<Hotel>().ToList<Hotel>());
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> Create(Hotel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok(new { msg = "Success" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest(new { msg = "Something went wrong" });
        }


        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Object>> GetUser(int id)
        {
            if (id == null || _context?.Hotels == null)
                return BadRequest(new { msg = "Id should not be null" });

            var user = await _context.Hotels.FindAsync(id);

            if (user == null)
                return NotFound(new { msg = $"User not found with id {id}" });


            return Ok(user);
        }
    }
}









