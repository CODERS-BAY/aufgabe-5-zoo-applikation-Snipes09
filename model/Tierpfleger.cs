using System.Collections;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Service;

namespace ZooAPI.model;

public class Tierpfleger : Mitarbeiter
{
    private static TierpflegerService _service;
    public ICollection<Animal> Animals { get; set; }



    public Tierpfleger()
    {
        _service = new TierpflegerService();
    }

    
    public async Task<ICollection<Animal>> GetAllAnimalsOfEmployeeById(int id)
    {
        return await _service.GetTiereByPflegerAsync(id);
    }

   
    public async Task<int> UpdateAnimal(Animal animal)
    {
        return await _service.UpdateTierAsync(animal);
    }
    
  
    public async Task<Animal> GetAnimalByName(string name)
    {
        return await _service.GetTierByNameAsync(name);
    }

  

}
