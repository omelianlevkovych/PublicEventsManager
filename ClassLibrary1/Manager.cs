using System;
namespace PublicEventsManager.Entities
{
    /// <summary>
    /// Represents a manager model
    /// </summary>
    public class Manager
{
    /// <summary>
    /// Gets or sets id value, primary key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets manager first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets manager last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets manager login 
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets manager password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether manager is disabled
    /// </summary>
    public bool IsDisabled { get; set; }
}
}
