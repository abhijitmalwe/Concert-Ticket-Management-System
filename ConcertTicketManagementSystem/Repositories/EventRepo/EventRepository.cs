using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;
using ConcertTicketManagementSystem.Infrastructure.DbPersistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConcertTicketManagementSystem.Repositories.EventRepo
{
    /// <summary>  
    /// Repository class for managing Event entities.  
    /// Provides methods for adding, updating, and retrieving events from the database.  
    /// </summary>  
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        /// <summary>  
        /// Initializes a new instance of the <see cref="EventRepository"/> class.  
        /// </summary>  
        /// <param name="context">The database context used for accessing the Events table.</param>  
        public EventRepository(AppDbContext context) => _context = context;

        /// <summary>  
        /// Adds a new event to the database.  
        /// </summary>  
        /// <param name="evt">The event entity to be added.</param>  
        /// <returns>The added event entity.</returns>  
        public async Task<Event> AddAsync(Event evt)
        {
            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
            return evt;
        }

        /// <summary>  
        /// Updates an existing event in the database.  
        /// </summary>  
        /// <param name="id">The ID of the event to be updated.</param>  
        /// <param name="dto">The DTO containing updated event details.</param>  
        /// <returns>The updated event entity.</returns>  
        /// <exception cref="Exception">Thrown when the event with the specified ID is not found.</exception>  
        public async Task<Event> UpdateAsync(int id, UpdateEventDto dto)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null) throw new Exception("Event not found");

            evt.Name = dto.Name;
            evt.Date = dto.Date;
            evt.Venue = dto.Venue;
            evt.Description = dto.Description;
            evt.Capacity = dto.Capacity;

            // Clear old ticket types and replace
            _context.TicketTypes.RemoveRange(evt.TicketTypes);
            evt.TicketTypes = dto.TicketTypes.Select(tt => new TicketType
            {
                Name = tt.Name,
                Price = tt.Price,
                EventId = id
            }).ToList();

            await _context.SaveChangesAsync();
            return evt;
        }

        /// <summary>  
        /// Retrieves an event by its ID.  
        /// </summary>  
        /// <param name="id">The ID of the event to retrieve.</param>  
        /// <returns>The event entity if found; otherwise, null.</returns>  
        public async Task<Event?> GetByIdAsync(int id)
        => await _context.Events.Include(e => e.TicketTypes).FirstOrDefaultAsync(e => e.Id == id);
    }
}
