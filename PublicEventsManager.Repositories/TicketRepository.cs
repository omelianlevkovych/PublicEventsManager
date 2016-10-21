using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PublicEventsManager.Entities;

namespace PublicEventsManager.Repositories
{
    //Reviewer OM: you don`t need summary everywhere
    /// <summary>
    /// Defines a repository for tickets
    /// </summary>
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        /// <summary>
        /// Initializes a new instance of TicketRepository class
        /// </summary>
        /// <param name="connectionString">Connection string to database</param>
        public TicketRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Reserves ticket for current owner based on his or her name
        /// </summary>
        /// <param name="ticketId">Ticket id value</param>
        /// <param name="ownerName">Owner full name</param>
        public void ReserveTicketById(int ticketId, string ownerName)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spReserveTicketById", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = ticketId;
                    command.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = ownerName;

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets collection of tickets based on owner name value that is passed
        /// </summary>
        /// <param name="ownerName">Owner full name</param>
        /// <returns>Collection of tickets</returns>
        public IEnumerable<Ticket> GetTicketsByOwnerName(string ownerName)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spGetTicketsByOwnerName", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = ownerName;

                    List<Ticket> ticketsList = new List<Ticket>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ticketsList.Add(new Ticket
                            {
                                Id = (int)reader["Id"],
                                OwnerName = (string)reader["OwnerName"],
                                Price = (decimal)reader["Price"],
                                PublicEventId = (int)reader["PublicEventId"]
                            });
                        }
                    }

                    return ticketsList;
                }
            }
        }

        /// <summary>
        /// Creates ticket for public event that is passed
        /// </summary>
        /// <param name="publicEvent">Public event for which ticket is created</param>
        /// <param name="ownerName">Ticket's owner name</param>
        /// <param name="price">Indicates how much ticket cost</param>
        public void CreateTicketForPublicEvent(PublicEvent publicEvent, string ownerName, decimal price)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spCreateTicketForPublicEvent", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@PublicEventId", SqlDbType.Int).Value = publicEvent.Id;
                    command.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = ownerName;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Changes all tickets price for public event that is passed
        /// </summary>
        /// <param name="publicEvent">Public event for which price is changed</param>
        /// <param name="price">Indicates how much ticket cost</param>
        public void ChangeTicketsPrice(PublicEvent publicEvent, decimal price)
        {
            using (SqlConnection connectionString = new SqlConnection(ConnectionString))
            {
                connectionString.Open();

                using (SqlCommand command = new SqlCommand("spChangePriceForTickets", connectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@PublicEventId", SqlDbType.Int).Value = publicEvent.Id;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
