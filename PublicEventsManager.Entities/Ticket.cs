using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Reivew IP: remove unused namespaces

namespace PublicEventsManager.Entities
{
    /// <summary>
    /// Represents a ticket model
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Gets or sets id value, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets public event id, foreign key
        /// </summary>
        public int PublicEventId { get; set; }

        /// <summary>
        /// Gets or sets owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets price value
        /// </summary>
        public decimal Price { get; set; }
    }
}
