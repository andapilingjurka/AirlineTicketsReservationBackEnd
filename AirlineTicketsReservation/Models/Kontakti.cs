using System.ComponentModel.DataAnnotations;

namespace AirlineTicketsReservation.Models
{
    public class Kontakti
    {
        [Key]
        public int KontaktID { get; set; }
        public string Emri { get; set; }
        public string Emaili { get; set; }
        public string NumriTelefonit { get; set; }
        public string Mesazhi { get; set; }


    }
}
