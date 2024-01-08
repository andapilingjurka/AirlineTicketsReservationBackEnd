using System.ComponentModel.DataAnnotations;

namespace AirlineTicketsReservation.Models
{
    public class Rezervimi
    {
        [Key]

        public int Id { get; set; }
        public string Klasi { get; set; }
        public long Cmimi { get; set; }
        public string Currency { get; set; }
        public int FluturimiId { get; set; }
        public Boolean Kthyese { get; set; }

        public int PerdoruesiId { get; set; }
        public Perdoruesi Perdoruesi { get; set; }
        public DateTimeOffset Data_e_Rezervimit { get; set; }
        public DateTime? Data_e_Kthimit = null;

        public Fluturimi Fluturimi { get; set; }
    }
}
