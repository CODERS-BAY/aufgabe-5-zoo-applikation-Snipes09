using ZooAPI.controller;
using ZooAPI.model;

namespace ZooAPI.Service;


public class TierpflegerService : DBConnectionService
{


    public TierpflegerService()
    {
        
    }


    
    public async Task<Animal> GetTierByNameAsync(string name)
    {
        Animal tier = new Animal();
        using (var db = await GetConnection())
        {
            using (var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tiere WHERE gattung = @gattung";
                command.Parameters.AddWithValue("@gattung", name);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {

                        tier.Id = reader.GetInt32(0);
                        tier.Gattung = reader.GetString(1);
                        tier.Nahrung = reader.GetString(2);
                        tier.GehegeId = reader.GetInt32(3);
                        tier.MitarbeiterId = reader.GetInt32(4);
                    }
                }
            }
        }
        return tier;
    }

    public async Task<ICollection<Animal>> GetAllAnimalsAsync()
    {
        var tiere = new List<Animal>();

        using (var db = await GetConnection())
        {
            using (var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tiere";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var tier = new Animal
                        {
                            Id = reader.GetInt32(0),
                            Gattung = reader.GetString(1),
                            Nahrung = reader.GetString(2),
                            GehegeId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            MitarbeiterId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                        };

                        tiere.Add(tier);
                    }
                }
            }
        }
        return tiere;
    }

    public async Task<ICollection<Animal>> GetTiereByPflegerAsync(int pflegerId)
    {
        var tiere = new List<Animal>();

        using (var db = await GetConnection())
        {
            using (var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tiere WHERE mitarbeiterId = @MitarbeiterId";
                command.Parameters.AddWithValue("@MitarbeiterId", pflegerId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var tier = new Animal
                        {
                            Id = reader.GetInt32(0),
                            Gattung = reader.GetString(1),
                            Nahrung = reader.GetString(2),
                            GehegeId = reader.GetInt32(3),
                            MitarbeiterId = reader.GetInt32(4)
                        };

                        tiere.Add(tier);
                    }
                }
            }
        }
        return tiere;
    }

    public async Task<int> UpdateTierAsync(Animal tier)
    {
        var result = 0;

        using (var db = await GetConnection())
        {
            using (var command = db.CreateCommand())
            {
                command.CommandText = @"UPDATE tiere 
                                        SET Gattung = @Gattung, Nahrung = @Nahrung, GehegeId = @GehegeId, mitarbeiterId = @MitarbeiterId 
                                        WHERE Id = @Id";

                command.Parameters.AddWithValue("@Gattung", tier.Gattung);
                command.Parameters.AddWithValue("@Nahrung", tier.Nahrung);
                command.Parameters.AddWithValue("@GehegeId", tier.GehegeId);
                command.Parameters.AddWithValue("@MitarbeiterId", tier.MitarbeiterId);
                command.Parameters.AddWithValue("@Id", tier.Id);

                result = await command.ExecuteNonQueryAsync();
            }
        }
        return result;
    }
}

