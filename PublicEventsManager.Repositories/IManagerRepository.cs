using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines an interface for manager repository
    /// </summary>
    public interface IManagerRepository
    {
        /// <summary>
        /// Gets a manager by login and password
        /// </summary>
        /// <param name="login">Manager login</param>
        /// <param name="password">Manager password</param>
        /// <returns>Manager item</returns>
        Manager GetManagerByLogin(string login, string password);
    }
}
