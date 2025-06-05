using ConcertTicketManagementSystem.DTOs;
using ConcertTicketManagementSystem.Services.TicketServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketManagementSystem.Controllers
{
    /// <summary>  
    /// Controller responsible for managing ticket availability, reservations, purchases, and cancellations.  
    /// </summary>  
    [ApiController]
    [Route("api/[controller]")]
    public class TicketAvailabilityController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        /// <summary>  
        /// Initializes a new instance of the <see cref="TicketAvailabilityController"/> class.  
        /// </summary>  
        /// <param name="ticketService">Service for handling ticket-related operations.</param>  
        public TicketAvailabilityController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>  
        /// Reserves a ticket for a given event.  
        /// </summary>  
        /// <param name="dto">Data transfer object containing reservation details.</param>  
        /// <returns>HTTP response indicating the result of the reservation operation.</returns>  
        [HttpPost("reserve")]
        public async Task<IActionResult> Reserve(ReserveTicketDto dto)
            => Ok(await _ticketService.ReserveTicketAsync(dto));

        /// <summary>  
        /// Purchases a ticket for a given event.  
        /// </summary>  
        /// <param name="dto">Data transfer object containing purchase details.</param>  
        /// <returns>HTTP response indicating the result of the purchase operation.</returns>  
        [HttpPost("purchase")]
        public async Task<IActionResult> Purchase(PurchaseTicketDto dto)
            => Ok(await _ticketService.PurchaseTicketAsync(dto));

        /// <summary>  
        /// Cancels a ticket reservation based on the ticket ID.  
        /// </summary>  
        /// <param name="ticketId">The ID of the ticket to cancel.</param>  
        /// <returns>HTTP response indicating the result of the cancellation operation.</returns>  
        [HttpDelete("cancel/{ticketId}")]
        public async Task<IActionResult> CancelReservation(int ticketId)
            => Ok(await _ticketService.CancelReservationAsync(ticketId));

        /// <summary>  
        /// Retrieves ticket availability for a specific event.  
        /// </summary>  
        /// <param name="eventId">The ID of the event to check ticket availability for.</param>  
        /// <returns>HTTP response containing ticket availability information.</returns>  
        [HttpGet("availability/{eventId}")]
        public async Task<IActionResult> GetAvailability(int eventId)
            => Ok(await _ticketService.GetTicketAvailabilityAsync(eventId));
    }
}
