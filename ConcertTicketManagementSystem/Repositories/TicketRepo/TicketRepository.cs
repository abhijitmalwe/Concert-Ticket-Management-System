using ConcertTicketManagementSystem.Domain;
using System.Net.Sockets;
using System;
using ConcertTicketManagementSystem.Infrastructure.DbPersistence;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketManagementSystem.Repositories.TicketRepo
{
    /// <summary>  
    /// Repository class for managing ticket-related operations.  
    /// </summary>  
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        /// <summary>  
        /// Initializes a new instance of the <see cref="TicketRepository"/> class.  
        /// </summary>  
        /// <param name="context">The database context for accessing ticket data.</param>  
        public TicketRepository(AppDbContext context) => _context = context;

        /// <summary>  
        /// Reserves a ticket asynchronously.  
        /// </summary>  
        /// <param name="ticket">The ticket to reserve.</param>  
        /// <returns>The reserved ticket.</returns>  
        public async Task<Ticket> ReserveTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        /// <summary>  
        /// Purchases a ticket asynchronously.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket to purchase.</param>  
        /// <returns>The purchased ticket.</returns>  
        /// <exception cref="Exception">Thrown if the ticket is invalid or cannot be purchased.</exception>  
        public async Task<Ticket> PurchaseTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null || ticket.IsPurchased || ticket.ReservedUntil < DateTime.UtcNow)
                throw new Exception("Invalid ticket");

            ticket.IsPurchased = true;
            await _context.SaveChangesAsync();
            return ticket;
        }

        /// <summary>  
        /// Cancels a ticket reservation asynchronously.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket to cancel.</param>  
        /// <returns>The canceled ticket.</returns>  
        /// <exception cref="Exception">Thrown if the ticket cannot be canceled.</exception>  
        public async Task<Ticket> CancelReservationAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null || ticket.IsPurchased)
                throw new Exception("Cannot cancel");

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        /// <summary>  
        /// Retrieves ticket availability for a specific event asynchronously.  
        /// </summary>  
        /// <param name="eventId">The ID of the event.</param>  
        /// <returns>A collection of ticket types available for the event.</returns>  
        public async Task<IEnumerable<TicketType>> GetTicketAvailabilityAsync(int eventId)
        {
            return await _context.TicketTypes
                .Where(tt => tt.EventId == eventId)
                .ToListAsync();
        }

        /// <summary>  
        /// Retrieves a ticket by its ID asynchronously.  
        /// </summary>  
        /// <param name="id">The ID of the ticket.</param>  
        /// <returns>The ticket if found; otherwise, null.</returns>  
        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
    }
}
