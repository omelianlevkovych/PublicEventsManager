namespace PublicEventsManager.Entities
{
    /// <summary>
    /// Represents a public event model
    /// </summary>
    public class PublicEvent
    {
        /// <summary>
        /// Gets or sets id value, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets manager id value, foreign key
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Gets or sets event type id value, foreign key
        /// </summary>
        public int EventTypeId { get; set; }

        /// <summary>
        /// Gets or sets event date id value, foreign key
        /// </summary>
        public int EventDateId { get; set; }

        /// <summary>
        /// Gets or sets public event name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets public event location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets public event description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets public event all tickets amount value
        /// </summary>
        public int TicketsAmount { get; set; }

        /// <summary>
        /// Gets or sets public event current available tickets amount value
        /// </summary>
        public int AvailableTicketsAmount { get; set; }

        /// <summary>
        /// Gets or sets public event avarage price value
        /// </summary>
        public decimal AvaragePrice { get; set; }

    }
}
