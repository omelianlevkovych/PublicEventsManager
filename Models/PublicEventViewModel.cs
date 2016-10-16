using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicEventsManager.Models
{
    /// <summary>
    /// Represents model of public event for UI
    /// </summary>
    public class PublicEventViewModel
    {
        /// <summary>
        /// Gets or sets public event name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description value
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets location value
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Get or sets price value
        /// </summary>
        public string Price { get; set; }
    }
}
