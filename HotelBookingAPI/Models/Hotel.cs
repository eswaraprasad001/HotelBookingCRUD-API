using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string HotelName { get; set; }

        public int Price { get; set; }

        public string location { get; set; }
    }
}
