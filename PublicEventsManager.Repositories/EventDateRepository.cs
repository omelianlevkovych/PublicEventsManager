using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    public class EventDateRepository : BaseRepository, IEventDateRepository
    {
        /// <summary>
        /// Initializes a new instance of the EventDateRepository class
        /// </summary>
        /// <param name="connectionString">Connection string to database</param>
        public EventDateRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates new public event date item
        /// </summary>
        /// <param name="eventDate"></param>
        public void CreateEventDate(EventDate eventDate)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spCreateEventDate", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@EventStart", SqlDbType.DateTime).Value = eventDate.EventStart;
                    command.Parameters.Add("@EventEnd", SqlDbType.DateTime).Value = eventDate.EventEnd;
                    command.Parameters.Add("@SaleStart", SqlDbType.DateTime).Value = eventDate.SaleStart;
                    command.Parameters.Add("@SaleEnd", SqlDbType.DateTime).Value = eventDate.SaleEnd;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Changes event date item
        /// </summary>
        /// <param name="eventDate"></param>
        public void ChangeEventDate(EventDate eventDate)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spUpdateEventDate", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = eventDate.Id;
                    command.Parameters.Add("@EventStart", SqlDbType.DateTime).Value = eventDate.EventStart;
                    command.Parameters.Add("@EventEnd", SqlDbType.DateTime).Value = eventDate.EventEnd;
                    command.Parameters.Add("@SaleStart", SqlDbType.DateTime).Value = eventDate.SaleStart;
                    command.Parameters.Add("@SaleEnd", SqlDbType.DateTime).Value = eventDate.SaleEnd;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
