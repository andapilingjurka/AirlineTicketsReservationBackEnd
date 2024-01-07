namespace AirlineTicketsReservation.Models
{
    public record AddStripePayment(
     string CardNumber,
     string ExpirationYear,
     string ExpirationMonth,
     string Cvc,
     string Email,
     string Currency,
     long Amount
 );
}
