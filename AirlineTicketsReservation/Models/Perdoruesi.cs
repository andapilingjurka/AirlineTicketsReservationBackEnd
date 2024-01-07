using System.ComponentModel.DataAnnotations;

namespace AirlineTicketsReservation.Models
{
    public class Perdoruesi
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }

    }
}
