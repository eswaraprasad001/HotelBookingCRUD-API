using Microsoft.EntityFrameworkCore;
namespace HotelBookingAPI.Models
   
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options)
        {

        }

    public DbSet<Hotel> Hotels { get; set; }
}
}
