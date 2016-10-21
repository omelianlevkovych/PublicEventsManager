namespace PublicEventsManager.Entities
{
    //Reviewer OM: you don`t need summary, purpose is clear by name
    /// <summary>
    /// Represents an event type model
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Gets or sets id value, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name value
        /// </summary>
        public string Name { get; set; }
    }
}
