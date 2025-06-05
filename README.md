Concert Ticket Management API - Functional Description
# Admin/Organizer Flow
### Create Event
Define core event details:

Name

Date

Venue

Description

Capacity (maximum number of tickets that can be issued)

Events are created using CreateEventDto via the POST /api/events endpoint.

### Update Event
Modify existing event metadata using UpdateEventDto via the PUT /api/events/{id} endpoint.

Allows updating:

Event name

Date

Venue

Description

Capacity

### Ticket Types (Per Event)
Each event can include multiple Ticket Types:

Each has a name and price

Ticket types are associated with the event during creation (manually through EF or extended DTO)

Note: In the current implementation, ticket types are defined as part of the Event model but are not created dynamically via a dedicated API.

# Customer Flow
### View Ticket Availability
Check current ticket availability for a given event and ticket type using GET /api/tickets/availability?eventId={id}

Returns number of tickets still available (excluding reserved/purchased)

### Reserve Tickets
Customers can reserve tickets temporarily by providing:

Event ID

Ticket Type ID

Customer Name

Reservation is valid for a time window (configured manually; e.g., 10 minutes)

API: POST /api/tickets/reserve

### Purchase Tickets
Purchase a ticket that was previously reserved using:

Ticket ID

Marks the ticket as purchased and reduces available count

API: POST /api/tickets/purchase

### Cancel Reservation (Optional in logic, not implemented as separate endpoint yet)
Reserved tickets can expire if not purchased in time

Expired reservations automatically return tickets to availability (handled via ReservedUntil)

### Reservation Logic
When a ticket is reserved, it is assigned a ReservedUntil time (e.g., now + 10 minutes)

If ReservedUntil is in the past and the ticket has not been purchased:

It is considered expired

The ticket is available again for reservation

Prevents overbooking or double-reserving

This logic is enforced in the TicketService during availability checks

### Technical Summary
Models Used: Event, Ticket, TicketType

DTOs: CreateEventDto, UpdateEventDto, ReserveTicketDto, PurchaseTicketDto

Persistence: Entity Framework Core + SQL Server (LocalDB)

Business Logic: Located in Services/

API Contracts: Exposed via Controllers/EventsController.cs and TicketsController.cs