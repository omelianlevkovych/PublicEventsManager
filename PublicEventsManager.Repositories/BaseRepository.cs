namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines abstract & root repository
    /// </summary>
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; }

        /// <summary>
        /// Initializes abstract base repository
        /// </summary>
        /// <param name="connectionString"></param>
        protected BaseRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
