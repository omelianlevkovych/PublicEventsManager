using System.Collections.Generic;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines an interface for ticket repository
    /// </summary>
    public interface ITicketRepository
    {
        /// <summary>
        /// Reserves ticket for current owner based on his or her name
        /// </summary>
        /// <param name="ticketId">Ticket id value</param>
        /// <param name="ownerName">Owner full name</param>
        void ReserveTicketById(int ticketId, string ownerName);

        /// <summary>
        /// Gets collection of tickets based on owner name value that is passed
        /// </summary>
        /// <param name="ownerName">Owner full name</param>
        /// <returns>Collection of tickets</returns>
        IEnumerable<Ticket> GetTicketsByOwnerName(string ownerName);

        /// <summary>
        /// Creates ticket for public event that is passed
        /// </summary>
        /// <param name="publicEvent">Public event for which ticket is created</param>
        /// <param name="ownerName">Ticket's owner name</param>
        /// <param name="price">Indicates how much ticket cost</param>
        void CreateTicketForPublicEvent(PublicEvent publicEvent, string ownerName, decimal price);

        /// <summary>
        /// Changes all tickets price for public event that is passed
        /// </summary>
        /// <param name="publicEvent">Public event for which price is changed</param>
        /// <param name="price">Indicates how much ticket cost</param>
        void ChangeTicketsPrice(PublicEvent publicEvent, decimal price);

    }
}
