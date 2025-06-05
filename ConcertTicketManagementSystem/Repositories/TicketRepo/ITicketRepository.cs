using ConcertTicketManagementSystem.Domain;
using System.Net.Sockets;

namespace ConcertTicketManagementSystem.Repositories.TicketRepo
{
    /// <summary>  
    /// Interface for managing ticket-related operations.  
    /// </summary>  
    public interface ITicketRepository
    {
        /// <summary>  
        /// Reserves a ticket asynchronously.  
        /// </summary>  
        /// <param name="ticket">The ticket to reserve.</param>  
        /// <returns>A task representing the asynchronous operation, containing the reserved ticket.</returns>  
        Task<Ticket> ReserveTicketAsync(Ticket ticket);

        /// <summary>  
        /// Purchases a ticket asynchronously.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket to purchase.</param>  
        /// <returns>A task representing the asynchronous operation, containing the purchased ticket.</returns>  
        Task<Ticket> PurchaseTicketAsync(int ticketId);

        /// <summary>  
        /// Cancels a ticket reservation asynchronously.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket reservation to cancel.</param>  
        /// <returns>A task representing the asynchronous operation, containing the canceled ticket.</returns>  
        Task<Ticket> CancelReservationAsync(int ticketId);

        /// <summary>  
        /// Retrieves ticket availability for a specific event asynchronously.  
        /// </summary>  
        /// <param name="eventId">The ID of the event to check ticket availability for.</param>  
        /// <returns>A task representing the asynchronous operation, containing a collection of ticket types available for the event.</returns>  
        Task<IEnumerable<TicketType>> GetTicketAvailabilityAsync(int eventId);

        /// <summary>  
        /// Retrieves a ticket by its ID asynchronously.  
        /// </summary>  
        /// <param name="id">The ID of the ticket to retrieve.</param>  
        /// <returns>A task representing the asynchronous operation, containing the ticket if found, or null if not found.</returns>  
        Task<Ticket?> GetTicketByIdAsync(int id);
    }
}
