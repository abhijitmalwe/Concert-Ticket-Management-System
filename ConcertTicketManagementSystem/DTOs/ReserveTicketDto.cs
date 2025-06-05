namespace ConcertTicketManagementSystem.DTOs
{
    public class ReserveTicketDto
    {
        public int EventId { get; set; }
        public int TicketTypeId { get; set; }
        public string CustomerName { get; set; }
    }
}
