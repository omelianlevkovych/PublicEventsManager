using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines an interface for event date repository
    /// </summary>
    public interface IEventDateRepository
    {
        /// <summary>
        /// Creates new public event date item
        /// </summary>
        /// <param name="eventDate">Event date item</param>
        void CreateEventDate(EventDate eventDate);

        /// <summary>
        /// Changes event date item
        /// </summary>
        /// <param name="eventDate">Event date item</param>
        void ChangeEventDate(EventDate eventDate);
    }
}
