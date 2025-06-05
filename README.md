# 🎟️ Concert Ticket Management API - Functional Description

---

## 🛠️ Admin/Organizer Flow

---

### ✅ Create Event

Define core event details:

- Name  
- Date  
- Venue  
- Description  
- Capacity (maximum number of tickets that can be issued)

**Endpoint:**  
`POST /api/events`  
Payload: `CreateEventDto`

---

### 🛠️ Update Event

Modify existing event metadata using `UpdateEventDto` via:  
`PUT /api/events/{id}`

Allows updating:

- Event name  
- Date  
- Venue  
- Description  
- Capacity

---

### 🎫 Ticket Types (Per Event)

Each event can include multiple ticket types:

- Each has a name and price  
- Ticket types are associated with the event during creation (manually through EF or extended DTO)

> ⚠️ *Currently, ticket types are not created via a dedicated API; they are part of the Event model.*

---

## 👤 Customer Flow

---

### 🔍 View Ticket Availability

Check current ticket availability for a given event and ticket type:  
**GET:** `/api/tickets/availability?eventId={id}`

Returns number of tickets still available (excluding reserved/purchased)

---

### ⏳ Reserve Tickets

Customers can reserve tickets temporarily by providing:

- Event ID  
- Ticket Type ID  
- Customer Name  

Reservation is valid for a configured time window (e.g., 10 minutes)

**POST:** `/api/tickets/reserve`  
Payload: `ReserveTicketDto`

---

### 💳 Purchase Tickets

Purchase a previously reserved ticket using:

- Ticket ID

Marks the ticket as purchased and reduces available count.

**POST:** `/api/tickets/purchase`  
Payload: `PurchaseTicketDto`

---

### ❌ Cancel Reservation

> ⚠️ Not implemented as a separate endpoint yet.

- Reserved tickets can expire if not purchased in time  
- Expired reservations return tickets to availability  
- Handled via `ReservedUntil` logic

---

### ⏱️ Reservation Logic

When a ticket is reserved:

- It’s assigned a `ReservedUntil` timestamp (e.g., now + 10 minutes)  
- If that time has passed and the ticket is still unpurchased:  
  - It becomes available again

✅ Prevents overbooking or double-reserving  
✅ Enforced in `TicketService` during availability checks

---

## 🧾 Technical Summary

---

- **Models:** `Event`, `Ticket`, `TicketType`  
- **DTOs:** `CreateEventDto`, `UpdateEventDto`, `ReserveTicketDto`, `PurchaseTicketDto`  
- **Persistence:** Entity Framework Core + SQL Server (LocalDB)  
- **Business Logic:** Located in `Services/`  
- **API Contracts:**  
  - `EventsController.cs`  
  - `TicketsController.cs`

---
