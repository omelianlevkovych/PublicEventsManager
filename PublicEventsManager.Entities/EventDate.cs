using System;
namespace PublicEventsManager.Entities
{
    //Reviewer OM: you don`t need summary, purpose is clear by name 
    /// <summary>
    /// Represents an event date model
    /// </summary>
    public class EventDate
    {
        /// <summary>
        /// Gets or sets id value, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets time when event start
        /// </summary>
        public DateTime EventStart { get; set; }

        /// <summary>
        /// Gets or sets time when event end 
        /// </summary>
        public DateTime EventEnd { get; set; }

        /// <summary>
        /// Gets or sets time when sale start
        /// </summary>
        public DateTime SaleStart { get; set; }

        /// <summary>
        /// Gets or sets time when sale end
        /// </summary>
        public DateTime SaleEnd { get; set; }
    }
}
