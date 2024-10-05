using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Utility;
using System.Data.SqlClient;

namespace PetPals.Dao
{
    public class DonationDao : IDonationDao
    {
        public Donation GetDonationByID(int donationId)
        {
            Donation donation = null;

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Donations WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@DonationID", donationId);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    donation = new CashDonation(
                        (string)reader["DonorName"],
                        (decimal)reader["DonationAmount"],
                        (DateTime)reader["DonationDate"]
                    )
                    {
                        DonationID = (int)reader["DonationID"]
                    };
                }

                sqlConnection.Close();
            }

            return donation;
        }
        public void RecordDonation(CashDonation cashDonation)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
            INSERT INTO Donations (DonorName, DonationAmount, DonationDate, DonationType) 
            VALUES (@DonorName, @DonationAmount, @DonationDate, @DonationType)"; // Check this part
                cmd.Connection = sqlConnection;

                // Add parameters
                cmd.Parameters.AddWithValue("@DonorName", cashDonation.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", cashDonation.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", cashDonation.DonationDate);
                cmd.Parameters.AddWithValue("@DonationType", "Cash"); // This should match your database schema

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        // Get all donations
        public List<Donation> GetAllDonations()
        {
            List<Donation> donations = new List<Donation>();

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Donations";
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var donation = new CashDonation(
                        (string)reader["DonorName"],
                        (decimal)reader["DonationAmount"],
                        (DateTime)reader["DonationDate"]
                    )
                    {
                        DonationID = (int)reader["DonationID"]
                    };
                    donations.Add(donation);
                }

                sqlConnection.Close();
            }

            return donations;
        }

        // Add a new donation
        public void AddDonation(Donation donationData)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Donations (DonorName,DonationAmount, DonationDate) 
                                VALUES (@DonorName, @DonationAmount, @DonationDate)";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@DonorName", donationData.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", donationData.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", donationData.DonationDate);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        // Update an existing donation
        public void UpdateDonation(Donation donationData)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Donations SET 
                                DonorName = @DonorName, 
                                DonationAmount = @DonationAmount, 
                                DonationDate = @DonationDate 
                                WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@DonorName", donationData.DonorName);
                cmd.Parameters.AddWithValue("@DonationAmount", donationData.DonationAmount);
                cmd.Parameters.AddWithValue("@DonationDate", donationData.DonationDate);
                cmd.Parameters.AddWithValue("@DonationID", donationData.DonationID);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        // Remove a donation
        public void DeleteDonation(int donationId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Donations WHERE DonationID = @DonationID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@DonationID", donationId);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

    }
}
     