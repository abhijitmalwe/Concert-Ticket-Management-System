using ConcertTicketManagementSystem.DTOs;
using ConcertTicketManagementSystem.Services.EventServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ConcertTicketManagementSystem.Controllers
{
    /// <summary>  
    /// Controller for managing event-related operations.  
    /// </summary>  
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        /// <summary>  
        /// Initializes a new instance of the <see cref="EventsController"/> class.  
        /// </summary>  
        /// <param name="eventService">Service for handling event-related business logic.</param>  
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>  
        /// Creates a new event.  
        /// </summary>  
        /// <param name="dto">Data transfer object containing event details.</param>  
        /// <returns>HTTP response with the result of the event creation.</returns>  
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto dto)
            => Ok(await _eventService.CreateEventAsync(dto));

        /// <summary>  
        /// Updates an existing event.  
        /// </summary>  
        /// <param name="id">The ID of the event to update.</param>  
        /// <param name="dto">Data transfer object containing updated event details.</param>  
        /// <returns>HTTP response with the result of the event update.</returns>  
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEventDto dto)
            => Ok(await _eventService.UpdateEventAsync(id, dto));
    }

}
