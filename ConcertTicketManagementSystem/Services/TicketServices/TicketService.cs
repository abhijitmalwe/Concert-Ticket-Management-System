using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;
using ConcertTicketManagementSystem.Infrastructure.DbPersistence;
using ConcertTicketManagementSystem.Repositories.TicketRepo;
using System.Net.Sockets;

namespace ConcertTicketManagementSystem.Services.TicketServices
{
    /// <summary>  
    /// Service class for managing ticket-related operations.  
    /// </summary>  
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        /// <summary>  
        /// Initializes a new instance of the <see cref="TicketService"/> class.  
        /// </summary>  
        /// <param name="repository">The ticket repository instance.</param>  
        public TicketService(ITicketRepository repository) => _repository = repository;

        /// <summary>  
        /// Reserves a ticket for a specific event and ticket type.  
        /// </summary>  
        /// <param name="dto">The reservation details.</param>  
        /// <returns>A task representing the asynchronous operation, containing the reserved ticket.</returns>  
        public async Task<Ticket> ReserveTicketAsync(ReserveTicketDto dto)
        {
            var ticket = new Ticket
            {
                EventId = dto.EventId,
                TicketTypeId = dto.TicketTypeId,
                CustomerName = dto.CustomerName,
                ReservedUntil = DateTime.UtcNow.AddMinutes(15),
                IsPurchased = false
            };
            return await _repository.ReserveTicketAsync(ticket);
        }

        /// <summary>  
        /// Purchases a reserved ticket.  
        /// </summary>  
        /// <param name="dto">The purchase details containing the ticket ID.</param>  
        /// <returns>A task representing the asynchronous operation, containing the purchased ticket.</returns>  
        public async Task<Ticket> PurchaseTicketAsync(PurchaseTicketDto dto)
            => await _repository.PurchaseTicketAsync(dto.TicketId);

        /// <summary>  
        /// Cancels a ticket reservation.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket reservation to cancel.</param>  
        /// <returns>A task representing the asynchronous operation, containing the canceled ticket.</returns>  
        public async Task<Ticket> CancelReservationAsync(int ticketId)
            => await _repository.CancelReservationAsync(ticketId);

        /// <summary>  
        /// Retrieves ticket availability for a specific event.  
        /// </summary>  
        /// <param name="eventId">The ID of the event to check ticket availability for.</param>  
        /// <returns>A task representing the asynchronous operation, containing a collection of ticket types available for the event.</returns>  
        public async Task<IEnumerable<TicketType>> GetTicketAvailabilityAsync(int eventId)
            => await _repository.GetTicketAvailabilityAsync(eventId);
    }
}
