using Microsoft.AspNetCore.Mvc;
using ZooAPI.model;
using ZooAPI.Service;

namespace ZooAPI.controller;

[Route("api/[controller]")]
[ApiController]
public class TierpflegerController : BaseController
{

    [HttpGet("GetAllAnimalsOfEmployeeById")]
    public async Task<IActionResult> GetAllAnimalsOfEmployeeById(int id)
    {        
        var model = new Tierpfleger();
        var animals = await model.GetAllAnimalsOfEmployeeById(id);
        return Ok(animals);
    }

  
    [HttpPost("UpdateAnimal")]
    public async Task<IActionResult> UpdateAnimal(Animal animal)
    {
        var model = new Tierpfleger();
        var res = await model.UpdateAnimal(animal);
        return Ok(res);
    }
    

    [HttpGet("GetAnimalByName")]
    public async Task<IActionResult> GetAnimalByName(string name)
    {
        var model = new Tierpfleger();
        var animal = await model.GetAnimalByName(name);
        return Ok(animal);
    }


  
   
}

