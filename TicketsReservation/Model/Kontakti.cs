using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.Model
{
    public class Kontakti
    {
        [Key]
        public int KontaktID { get; set; }
        public string Emri { get; set; }
        public string Emaili { get; set; }
        public string Mesazhi { get; set; }


    }
}
