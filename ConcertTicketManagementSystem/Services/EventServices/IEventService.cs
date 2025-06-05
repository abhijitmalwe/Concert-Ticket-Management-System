using ConcertTicketManagementSystem.Domain;
using ConcertTicketManagementSystem.DTOs;

namespace ConcertTicketManagementSystem.Services.EventServices
{
    public interface IEventService
    {
        Task<Event> CreateEventAsync(CreateEventDto dto);
        Task<Event> UpdateEventAsync(int id, UpdateEventDto dto);
    }
}
