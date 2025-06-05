using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;

namespace ConcertTicketManagementSystem.Repositories.EventRepo
{
    /// <summary>  
    /// Interface for managing event-related data operations.  
    /// </summary>  
    public interface IEventRepository
    {
        /// <summary>  
        /// Adds a new event to the repository.  
        /// </summary>  
        /// <param name="evt">The event object to be added.</param>  
        /// <returns>A task representing the asynchronous operation, containing the added event.</returns>  
        Task<Event> AddAsync(Event evt);

        /// <summary>  
        /// Updates an existing event in the repository.  
        /// </summary>  
        /// <param name="id">The unique identifier of the event to be updated.</param>  
        /// <param name="dto">The data transfer object containing updated event details.</param>  
        /// <returns>A task representing the asynchronous operation, containing the updated event.</returns>  
        Task<Event> UpdateAsync(int id, UpdateEventDto dto);

        /// <summary>  
        /// Retrieves an event by its unique identifier.  
        /// </summary>  
        /// <param name="id">The unique identifier of the event to retrieve.</param>  
        /// <returns>A task representing the asynchronous operation, containing the event if found, or null if not.</returns>  
        Task<Event?> GetByIdAsync(int id);
    }
}
