using Microsoft.EntityFrameworkCore;

namespace ConcertTicketManagementSystem.Domain
{
    /// <summary>
    /// Represents a type of ticket available for an event.
    /// </summary>
    public class TicketType
    {
        /// <summary>
        /// Unique identifier for the ticket type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key referencing the associated event.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Name or description of the ticket type (e.g., "VIP", "General Admission").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the ticket type, with precision up to 18 digits and 2 decimal places.
        /// </summary>
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property for the associated event.
        /// </summary>
        public Event Event { get; set; }
    }
}
