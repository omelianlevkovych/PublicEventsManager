using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines an interface for event type repository
    /// </summary>
    public interface IEventTypeRepository
    {
        /// <summary>
        /// Gets collection of all public event types
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventType> GetAllEventTypes();

        /// <summary>
        /// Creates new public event type item
        /// </summary>
        /// <param name="EventType">Event type item</param>
        void CreateEventType(EventType eventType);

        /// <summary>
        /// Changes event type item
        /// </summary>
        /// <param name="EventType">Event type item</param>
        void ChangeEventType(EventType eventType);
    }
}
