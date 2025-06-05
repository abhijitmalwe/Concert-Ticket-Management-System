using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;
using ConcertTicketManagementSystem.Repositories.EventRepo;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketManagementSystem.Services.EventServices
{
    /// <summary>  
    /// Service class for managing events.  
    /// Provides methods to create and update event entities.  
    /// </summary>  
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        /// <summary>  
        /// Initializes a new instance of the <see cref="EventService"/> class.  
        /// </summary>  
        /// <param name="repository">The event repository instance.</param>  
        public EventService(IEventRepository repository) => _repository = repository;

        /// <summary>  
        /// Creates a new event asynchronously.  
        /// </summary>  
        /// <param name="dto">The data transfer object containing event details.</param>  
        /// <returns>The created <see cref="Event"/> entity.</returns>  
        public async Task<Event> CreateEventAsync(CreateEventDto dto)
        {
            var evt = new Event
            {
                Name = dto.Name,
                Date = dto.Date,
                Venue = dto.Venue,
                Description = dto.Description,
                Capacity = dto.Capacity,
                TicketTypes = dto.TicketTypes.Select(tt => new TicketType
                {
                    Name = tt.Name,
                    Price = tt.Price
                }).ToList()
            };
            return await _repository.AddAsync(evt);
        }

        /// <summary>  
        /// Updates an existing event asynchronously.  
        /// </summary>  
        /// <param name="id">The unique identifier of the event to update.</param>  
        /// <param name="dto">The data transfer object containing updated event details.</param>  
        /// <returns>The updated <see cref="Event"/> entity.</returns>  
        public async Task<Event> UpdateEventAsync(int id, UpdateEventDto dto)
            => await _repository.UpdateAsync(id, dto);
    }
}
