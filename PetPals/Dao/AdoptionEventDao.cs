using PetPals.Model;
using PetPals.Utility;
using System.Data.SqlClient;

namespace PetPals.Dao
{
    public class AdoptionEventDao : IAdoptionEventDao
    {
        public AdoptionEvent GetAdoptionEventByID(int eventId)
        {
            AdoptionEvent adoptionEvent = null;

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM AdoptionEvents WHERE EventID = @EventID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@EventID", eventId);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    adoptionEvent = new AdoptionEvent()
                    {
                        EventID = (int)reader["EventID"],
                        EventName = (string)reader["EventName"],
                        EventDate=(DateTime)reader["EventDate"],
                        Location = (string)reader["Location"],
                       
                    };
                }

                sqlConnection.Close();
            }

            return adoptionEvent;
        }

        public void AddAdoptionEvent(AdoptionEvent adoptionEvent)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO AdoptionEvents (EventName, EventDate, Location) 
                            VALUES (@EventName, @EventDate, @Location)";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@EventName", adoptionEvent.EventName);
                cmd.Parameters.AddWithValue("@EventDate", adoptionEvent.EventDate); 
                cmd.Parameters.AddWithValue("@Location", adoptionEvent.Location);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateAdoptionEvent(AdoptionEvent adoptionEventData)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE AdoptionEvents SET 
                                EventName = @EventName, 
                                EventDate = @EventDate, 
                                Location = @Location 
                            WHERE EventID = @EventID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@EventName", adoptionEventData.EventName);
                cmd.Parameters.AddWithValue("@EventDate", adoptionEventData.EventDate);
                cmd.Parameters.AddWithValue("@Location", adoptionEventData.Location);
                cmd.Parameters.AddWithValue("@EventID", adoptionEventData.EventID);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeleteAdoptionEvent(int eventId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM AdoptionEvents WHERE EventID = @EventID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@EventID", eventId);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<AdoptionEvent> GetAllAdoptionEvents()
        {
            List<AdoptionEvent> adoptionEvents = new List<AdoptionEvent>();

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM AdoptionEvents";
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdoptionEvent adoptionEvent = new AdoptionEvent()
                    {
                        EventID = (int)reader["EventID"],
                        EventName = (string)reader["EventName"],
                        EventDate = (DateTime)reader["EventDate"],
                        Location = (string)reader["Location"],
                        // Add other properties as needed
                    };

                    adoptionEvents.Add(adoptionEvent);
                }

                sqlConnection.Close();
            }

            return adoptionEvents;
        }
    }
}
