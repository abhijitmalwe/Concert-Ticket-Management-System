using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;
using System.Net.Sockets;

namespace ConcertTicketManagementSystem.Services.TicketServices
{
    public interface ITicketService
    {
        Task<Ticket> ReserveTicketAsync(ReserveTicketDto dto);
        Task<Ticket> PurchaseTicketAsync(PurchaseTicketDto dto);
        Task<Ticket> CancelReservationAsync(int ticketId);
        Task<IEnumerable<TicketType>> GetTicketAvailabilityAsync(int eventId);
    }
}
