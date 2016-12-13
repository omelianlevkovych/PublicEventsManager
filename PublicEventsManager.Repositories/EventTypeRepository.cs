using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicEventsManager.Entities;
using System.Data;
using System.Data.SqlClient;

namespace PublicEventsManager.Repositories
{
    public class EventTypeRepository : BaseRepository, IEventTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the EventTypeRepository class
        /// </summary>
        /// <param name="connectionString">Connection string to database</param>
        public EventTypeRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Gets collection of all public event types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EventType> GetAllEventTypes()
        {
            using (var connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (var command = new SqlCommand("SELECT Id, Name FROM EventType", connectionString))
                {
                    var eventsTypeList = new List<EventType>();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventsTypeList.Add(new EventType
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            });
                        }

                    }
                    return eventsTypeList;
                }

            }
        }

        /// <summary>
        /// Creates new public event type item
        /// </summary>
        // Review IP: wrong param name, sholud be eventType
        /// <param name="EventType">Event type item</param>
        public void CreateEventType(EventType eventType)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spCreateEventType", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = eventType.Name;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Changes event type item
        /// </summary>
        /// <param name="EventType">Event type item</param>
        public void ChangeEventType(EventType eventType)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spCreateEventType", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = eventType.Name;
                    command.Parameters.Add("@EventTypeId", SqlDbType.Int).Value = eventType.Id;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
