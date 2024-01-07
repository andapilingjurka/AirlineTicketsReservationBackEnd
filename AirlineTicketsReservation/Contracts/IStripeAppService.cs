
using System;
using AirlineTicketsReservation.Models;


namespace AirlineTicketsReservation.Contracts
{
    public interface IStripeAppService
    {
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}
