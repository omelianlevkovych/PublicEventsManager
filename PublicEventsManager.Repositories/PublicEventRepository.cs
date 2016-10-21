using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    /// <summary>
    /// Defines a repository for public events
    /// </summary>
    public class PublicEventRepository : BaseRepository, IPublicEventRepository
    {
        /// <summary>
        /// Initializes a new instance of the PublicEventRepository class
        /// </summary>
        /// <param name="connectionString">Connection string to database</param>
        public PublicEventRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Gets collection of all public events
        /// </summary>
        /// <returns>Collection of public events</returns>
        public IEnumerable<PublicEvent> GetAllPublicEvents()
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spGetAllPublicEvents", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    List<PublicEvent> publicEventsList = new List<PublicEvent>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            publicEventsList.Add(new PublicEvent
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Location = (string)reader["Location"],
                                Description = (string)reader["Description"],
                                TicketsAmount = (int)reader["TicketsAmount"],
                                AvailableTicketsAmount = (int)reader["AvailableTicketsAmount"],
                                ManagerId = (int)reader["ManagerId"],
                                EventDateId = (int)reader["DateId"],
                                EventTypeId = (int)reader["TypeId"],
                                AvaragePrice = (decimal)reader["Price"]
                            });
                        }
                    }

                    return publicEventsList;
                }
            }
        }

        /// <summary>
        /// Get collection of public events based on type name value
        /// </summary>
        /// <param name="typeName">Type name value</param>
        /// <returns>Collection of public events</returns>
        public IEnumerable<PublicEvent> GetAllPublicEventsByTypeName(string typeName)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spGetAllPublicEventsByTypeName", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@TypeName", SqlDbType.NVarChar).Value = typeName;

                    List<PublicEvent> publicEventList = new List<PublicEvent>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            publicEventList.Add(new PublicEvent
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Location = (string)reader["Location"],
                                Description = (string)reader["Description"],
                                TicketsAmount = (int)reader["TicketsAmount"],
                                AvailableTicketsAmount = (int)reader["AvailableTicketsAmount"],
                                ManagerId = (int)reader["ManagerId"],
                                EventDateId = (int)reader["EventDateId"]
                            }); 
                        }
                    }

                    return publicEventList;
                }
            }
        }

        /// <summary>
        /// Get public event based on its id
        /// </summary>
        /// <param name="id">Id value</param>
        /// <returns>Public event item</returns>
        public PublicEvent GetPublicEventById(int id)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spGetPublicEventById", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        PublicEvent publicEvent = null;
                        if (reader.Read())
                        {
                            publicEvent = new PublicEvent();
                            publicEvent.Id = (int)reader["Id"];
                            publicEvent.Location = (string)reader["Location"];
                            publicEvent.ManagerId = (int)reader["ManagerId"];
                            publicEvent.Name = (string)reader["Name"];
                            publicEvent.TicketsAmount = (int)reader["TicketsAmount"];
                            publicEvent.AvailableTicketsAmount = (int)reader["AvailableTicketsAmount"];
                            publicEvent.Description = (string)reader["Description"];
                            publicEvent.EventDateId = (int)reader["EventDateId"];
                            publicEvent.EventTypeId = (int)reader["EventTypeId"];
                        }

                        return publicEvent;
                    }
                }
            }
        }

        /// <summary>
        /// Create new public event item
        /// </summary>
        /// <param name="publicEvent">Public event item</param>
        public void AddNewPublicEvent(PublicEvent publicEvent)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spInsertPublicEvent", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = publicEvent.Id;
                    command.Parameters.Add("@ManagerId", SqlDbType.Int).Value = publicEvent.ManagerId;
                    command.Parameters.Add("@EventTypeId", SqlDbType.Int).Value = publicEvent.EventTypeId;
                    command.Parameters.Add("@EventDateId", SqlDbType.Int).Value = publicEvent.EventDateId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = publicEvent.Name;
                    command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = publicEvent.Location;
                    command.Parameters.Add("@Description", SqlDbType.NText).Value = publicEvent.Description;
                    command.Parameters.Add("@TicketsAmount", SqlDbType.Int).Value = publicEvent.TicketsAmount;
                    command.Parameters.Add("@AvailableTicketsAmount", SqlDbType.Int).Value = publicEvent.AvailableTicketsAmount;

                    command.ExecuteNonQuery();
                }
            }
        }

        //Reviewer OM: invalid name of stored procedure . Should be spUpdatePublicEvent. 
        //Reviewer OM: Better to declare stored procedure`s names in one summary of repository
        /// <summary>
        /// Updates public event item
        /// </summary>
        /// <param name="publicEvent">Public event item</param>
        public void UpdatePublicEvent(PublicEvent publicEvent)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spInsertPublicEvent", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = publicEvent.Id;
                    command.Parameters.Add("@ManagerId", SqlDbType.Int).Value = publicEvent.ManagerId;
                    command.Parameters.Add("@EventTypeId", SqlDbType.Int).Value = publicEvent.EventTypeId;
                    command.Parameters.Add("@EventDateId", SqlDbType.Int).Value = publicEvent.EventDateId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = publicEvent.Name;
                    command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = publicEvent.Location;
                    command.Parameters.Add("@Description", SqlDbType.NText).Value = publicEvent.Description;
                    command.Parameters.Add("@TicketsAmount", SqlDbType.Int).Value = publicEvent.TicketsAmount;
                    command.Parameters.Add("@AvailableTicketsAmount", SqlDbType.Int).Value = publicEvent.AvailableTicketsAmount;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
