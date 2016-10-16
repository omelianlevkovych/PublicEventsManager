using PublicEventsManager.Entities;
using System.Data;
using System.Data.SqlClient;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines a repository for managers
    /// </summary>
    public class ManagerRepository : BaseRepository, IManagerRepository
    {
        /// <summary>
        /// Initializes a new instance of the ManagerRepository class
        /// </summary>
        /// <param name="connectionString">Connection string to database</param>
        public ManagerRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Gets a manager by login and password
        /// </summary>
        /// <param name="login">Manager login</param>
        /// <param name="password">Manager password</param>
        /// <returns>Manager item</returns>
        public Manager GetManagerByLogin(string login, string password)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();
                using (SqlCommand command = new SqlCommand("spGetManagerByLogin", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Manager manager = null;
                        
                        if (reader.Read())
                        {
                            manager = new Manager();
                            manager.Id = (int)reader["Id"];
                            manager.FirstName = (string)reader["FirstName"];
                            manager.LastName = (string)reader["LastName"];
                            manager.Login = (string)reader["Login"];
                            manager.IsDisabled = (bool)reader["IsDisabled"];
                        }

                        return manager;
                    }
                }   
            }
        }
    }
}
