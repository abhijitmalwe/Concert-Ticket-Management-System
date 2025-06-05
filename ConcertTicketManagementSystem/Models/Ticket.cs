namespace ConcertTicketManagementSystem.Domain
{
    public class Ticket
    {
        // Unique identifier for the ticket  
        public int Id { get; set; }

        // Foreign key linking the ticket to a specific event  
        public int EventId { get; set; }

        // Foreign key linking the ticket to a specific ticket type  
        public int TicketTypeId { get; set; }

        // Name of the customer who reserved or purchased the ticket  
        public string CustomerName { get; set; }

        // Date and time until the ticket is reserved  
        public DateTime ReservedUntil { get; set; }

        // Indicates whether the ticket has been purchased  
        public bool IsPurchased { get; set; }

        // Navigation property for the associated event  
        public Event Event { get; set; }

        // Navigation property for the associated ticket type  
        public TicketType TicketType { get; set; }
    }
}
