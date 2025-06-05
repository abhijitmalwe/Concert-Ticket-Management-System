namespace ConcertTicketManagementSystem.Domain
{
    public class Event
    {
        // Unique identifier for the event  
        public int Id { get; set; }

        // Name of the event  
        public string Name { get; set; }

        // Date and time when the event will take place  
        public DateTime Date { get; set; }

        // Venue where the event will be held  
        public string Venue { get; set; }

        // Description providing details about the event  
        public string Description { get; set; }

        // Maximum number of attendees allowed for the event  
        public int Capacity { get; set; }

        // Collection of ticket types available for the event  
        public ICollection<TicketType> TicketTypes { get; set; }
    

    
}
