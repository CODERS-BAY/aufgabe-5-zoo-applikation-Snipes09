using MySqlConnector;
using ZooAPI.controller;
using ZooAPI.model;

namespace ZooAPI.Service;



public class KassiererService : DBConnectionService
{
    
    
    public KassiererService()
    {         
    }
  
    public async Task<Kassierer> GetKassiererByIdAsync(int id)
    {
        Kassierer kassierer = null;        
        using (var con  = await GetConnection())
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM mitarbeiter WHERE id =@id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        kassierer = new Kassierer
                        {
                            Id = reader.GetInt32(0),
                            Position = reader.GetString(1),
                            MitarbeiterAlter = reader.GetInt32(2),
                            Name = reader.GetString(3)
                        };
                }
            }
        }
        return kassierer;
    }

  
    public async Task<Kassierer> GetKassiererByNameAsync(string name)
    {
        Kassierer kassierer = null;
        using (var con = await GetConnection())
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM mitarbeiter WHERE name =@name";
                command.Parameters.AddWithValue("@name", name);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        kassierer = new Kassierer
                        {
                            Id = reader.GetInt32(0),
                            Position = reader.GetString(1),
                            MitarbeiterAlter = reader.GetInt32(2),
                            Name = reader.GetString(3)
                        };
                }
            }
        }
        return kassierer;
    }

    public async Task<int> SaveTicket(int userId) // UserId vom Kassierer/Mitarbeiter
    {
        var ticket = new Ticket
        {
            Datum = DateTime.Today,
            Verkaufsdatum = DateTime.Today,
            Preis = 10,
            UserId = 1
        };
        var affectedRows = 0;
        using (var con = await GetConnection())
        {
            using (var command = new MySqlCommand("INSERT INTO tickets (Datum, Verkaufsdatum, Preis, UserId) VALUES" +
                                                  "(@Datum, @Verkaufsdatum, @Preis, @UserId)", con))
            {
                command.Parameters.AddWithValue("@Datum", ticket.Datum);
                command.Parameters.AddWithValue("@Verkaufsdatum", ticket.Verkaufsdatum);
                command.Parameters.AddWithValue("@Preis", ticket.Preis);
                command.Parameters.AddWithValue("@UserId", ticket.UserId);
                affectedRows = await command.ExecuteNonQueryAsync();
            }
        }
        return affectedRows;
    } 

   
    public async Task<ICollection<Ticket>> GetAllTickets()
    {
        var tickets = new List<Ticket>();
        using (var con = await GetConnection())
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tickets";
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var ticket = new Ticket
                        {
                            Id = reader.GetInt32(0),
                            Datum = reader.GetDateTime(1),
                            Verkaufsdatum = reader.GetDateTime(2),
                            Preis = reader.GetDecimal(3),
                            UserId = reader.GetInt32(4)
                        };
                        tickets.Add(ticket);
                    }
                }
            }
        }
        return tickets;
    }

  
    public async Task<ICollection<Ticket>> GetTicketsByDateAsync(DateTime date)
    {
        var tickets = new List<Ticket>();

        using (var con = await GetConnection())
        {
            using (var command = con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tickets WHERE datum = @Datum";
                command.Parameters.AddWithValue("@Datum", date);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var ticket = new Ticket
                        {
                            Id = reader.GetInt32(0),
                            Datum = reader.GetDateTime(1),
                            Verkaufsdatum = reader.GetDateTime(2),
                            Preis = reader.GetDecimal(3),
                            UserId = reader.GetInt32(4)
                        };
                        tickets.Add(ticket);
                    }
                }
            }
        }
        return tickets;
    }



}

