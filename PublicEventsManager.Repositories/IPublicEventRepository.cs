using System.Collections.Generic;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines an interface for public event repository
    /// </summary>
    public interface IPublicEventRepository
    {
        //Reviewer OM: you don`t need summary, purpose is clear by name 
        /// <summary>
        /// Gets collection of all public events
        /// </summary>
        /// <returns>Collection of public events</returns>
        IEnumerable<PublicEvent> GetAllPublicEvents();

        /// <summary>
        /// Get collection of public events based on type name value
        /// </summary>
        /// <param name="typeName">Type name value</param>
        /// <returns>Collection of public events</returns>
        IEnumerable<PublicEvent> GetAllPublicEventsByTypeName(string typeName);

        /// <summary>
        /// Get public event based on its id
        /// </summary>
        /// <param name="id">Id value</param>
        /// <returns>Public event item</returns>
        PublicEvent GetPublicEventById(int id);

        /// <summary>
        /// Create new public event item
        /// </summary>
        /// <param name="publicEvent">Public event item</param>
        void AddNewPublicEvent(PublicEvent publicEvent);

        /// <summary>
        /// Updates public event item
        /// </summary>
        /// <param name="publicEvent">Public event item</param>
        void UpdatePublicEvent(PublicEvent publicEvent);
    }
}
