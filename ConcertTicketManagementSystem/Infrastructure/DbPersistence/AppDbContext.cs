using ConcertTicketManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ConcertTicketManagementSystem.Infrastructure.DbPersistence
{
    /// <summary>  
    /// Represents the application's database context, providing access to the database tables and configurations.  
    /// </summary>  
    public class AppDbContext : DbContext
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="AppDbContext"/> class with the specified options.  
        /// </summary>  
        /// <param name="options">The options to configure the database context.</param>  
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>  
        /// Gets or sets the DbSet for the Event entity.  
        /// </summary>  
        public DbSet<Event> Events { get; set; }

        /// <summary>  
        /// Gets or sets the DbSet for the Ticket entity.  
        /// </summary>  
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>  
        /// Gets or sets the DbSet for the TicketType entity.  
        /// </summary>  
        public DbSet<TicketType> TicketTypes { get; set; }

        /// <summary>  
        /// Configures the entity relationships and constraints for the database context.  
        /// </summary>  
        /// <param name="modelBuilder">The builder used to configure the entity models.</param>  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the relationship between Event and TicketType entities.  
            modelBuilder.Entity<Event>()
                .HasMany(e => e.TicketTypes)
                .WithOne(t => t.Event)
                .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade); // keep one cascade

            

            // Ticket → TicketType (disable cascade to prevent conflict)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TicketType)
                .WithMany()
                .HasForeignKey(t => t.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict); // prevent multiple cascade paths

            // TicketType → Event (also restrict to avoid cycle)
            modelBuilder.Entity<TicketType>()
                .HasOne(tt => tt.Event)
                .WithMany()
                .HasForeignKey(tt => tt.EventId)
                .OnDelete(DeleteBehavior.Restrict); // no cascade here either
        }
    }
}
