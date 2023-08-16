using Microsoft.JSInterop.Infrastructure;
using MySqlConnector;
using ZooAPI.controller;
using ZooAPI.model;

namespace ZooAPI.Service;

public class ZoobesucherService : DBConnectionService
{
   

    public ZoobesucherService()
    {
       
    }

   
    public async Task<Animal> GetAnimalByNameAsync(string gattung)
    {
        Animal animal = new Animal();
        using (var conn = await GetConnection())
        {
            using (var command = conn.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM tiere WHERE gattung =@gattung";
                command.Parameters.AddWithValue("@gattung", gattung);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    animal.Id = reader.GetInt32(0);
                    animal.Gattung = reader.GetString(1);
                    animal.Nahrung = reader.GetString(2);
                }
            }
        }
        return animal;
    }


    public async Task<ICollection<Animal>> GetAllAnimalsOfZooAsync()
    {
        var animals = new List<Animal>();
        using (var conn = await GetConnection())
        {
            using (var command = conn.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM tiere ";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var animal = new Animal
                        {
                            Id = reader.GetInt32(0),
                            Gattung = reader.GetString(1),
                            Nahrung = reader.GetString(2),

                        };
                        animals.Add(animal);
                    }
                }
            }
        }
        return animals;
    }

}



