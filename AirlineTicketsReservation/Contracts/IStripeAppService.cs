
using System;
using AirlineTicketsReservation.Models;
using AirlineTicketsReservation.Models.Stripe;


namespace AirlineTicketsReservation.Contracts
{
    public interface IStripeAppService
    {
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}
