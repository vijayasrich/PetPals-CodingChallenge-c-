using PetPals.Utility;
using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    internal class PetDao : IPetDao
    {
        public Pet GetPetByID(int petId)
        {
            Pet pet = null;

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Pets WHERE PetID = @PetID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@PetID", petId);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pet = new Pet()
                    {
                        PetID = (int)reader["PetID"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Breed = (string)reader["Breed"],
                        Type=(string) reader["Type"],

                        // Add other properties as needed
                    };
                }

                sqlConnection.Close();
            }

            return pet;
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Pets";
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pet pet = new Pet()
                    {
                        PetID = (int)reader["PetID"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Breed = (string)reader["Breed"],
                        Type=(string)reader["Type"]
                        // Add other properties as needed
                    };

                    pets.Add(pet);
                }

                sqlConnection.Close();
            }

            return pets;
        }

        public void AddPet(Pet pet)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Pets (Name, Age, Breed, Type) 
                            VALUES (@Name, @Age, @Breed, @Type)";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@Name", pet.Name);
                cmd.Parameters.AddWithValue("@Age", pet.Age);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Parameters.AddWithValue("@Type", pet.Type); // Ensure this line exists

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdatePet(Pet petData)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Pets SET 
                                Name = @Name, 
                                Age = @Age, 
                                Breed= @breed,
                                Type=@type
                                WHERE PetID = @PetID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@Name", petData.Name);
                cmd.Parameters.AddWithValue("@Age", petData.Age);
                cmd.Parameters.AddWithValue("@Breed", petData.Breed);
                cmd.Parameters.AddWithValue("Type", petData.Type);
                cmd.Parameters.AddWithValue("@PetID", petData.PetID);
                
                // Add other properties as needed

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeletePet(int petId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Pets WHERE PetID = @PetID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@PetID", petId);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public List<Pet> DisplayPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Pets"; // Assuming 'Pets' is your table name
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pet pet = new Pet
                    {
                        PetID = (int)reader["PetID"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Breed = (string)reader["Breed"],
                        Type=(string)reader["Type"],
                    };

                    pets.Add(pet);
                }

                sqlConnection.Close();
            }

            return pets; // Return the list of pets
        }
    }
}

  

