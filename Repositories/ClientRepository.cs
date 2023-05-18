using Full_Stack_Mercury_Maps.Models;
using Full_Stack_Mercury_Maps.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class ClientRepository : IClientRepository
{
    private readonly string _connectionString;

    public ClientRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    // Method to get client by ID
    public Client GetClientById(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clients WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Client client = new Client
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Phone = reader.GetInt32(reader.GetOrdinal("Phone")),
                        HasBC = reader.GetBoolean(reader.GetOrdinal("HasBC")),
                        NewClient = reader.GetBoolean(reader.GetOrdinal("NewClient")),
                        Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"))
                    };

                    return client;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    // Method to add a new client
    public void AddClient(Client client)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Clients (UserId, Name, Phone, HasBC, NewClient, Birthday) VALUES (@userId, @name, @phone, @hasBC, @newClient, @birthday);", conn))
            {
                cmd.Parameters.AddWithValue("@userId", client.UserId);
                cmd.Parameters.AddWithValue("@name", client.Name);
                cmd.Parameters.AddWithValue("@phone", client.Phone);
                cmd.Parameters.AddWithValue("@hasBC", client.HasBC);
                cmd.Parameters.AddWithValue("@newClient", client.NewClient);
                cmd.Parameters.AddWithValue("@birthday", client.Birthday);

                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to update a client
    public void UpdateClient(Client client)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Clients SET UserId = @userId, Name = @name, Phone = @phone, HasBC = @hasBC, NewClient = @newClient, Birthday = @birthday WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@userId", client.UserId);
                cmd.Parameters.AddWithValue("@name", client.Name);
                cmd.Parameters.AddWithValue("@phone", client.Phone);
                cmd.Parameters.AddWithValue("@hasBC", client.HasBC);
                cmd.Parameters.AddWithValue("@newClient", client.NewClient);
                cmd.Parameters.AddWithValue("@birthday", client.Birthday);

                cmd.ExecuteNonQuery();
            }
        }
    }

    // Method to delete a client
    public void DeleteClient(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Clients WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
