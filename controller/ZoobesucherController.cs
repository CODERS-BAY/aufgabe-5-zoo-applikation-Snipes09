using Microsoft.AspNetCore.Mvc;
using ZooAPI.controller;
using ZooAPI.model;
using ZooAPI.Service;

namespace ZooAPI.controller;


[Route("api/[controller]")]
[ApiController]
public class ZoobesucherController : BaseController
{  
   
    public ZoobesucherController()
    {
    }

   
    [HttpGet("GetAnimalByAnimalName")]
    public async Task<IActionResult> GetAnimalByAnimalName(string name)
    {
        var model = new Zoobesucher();
        var item = await model.GetAnimalByAnimalName(name);
        return CreatedAtAction(nameof(GetAnimalByAnimalName), item,
            new { Animal = item });
    }

   
    [HttpGet("GetAllAnimalsOfZoo")]
    public async Task<IActionResult> GetAllAnimalsOfZoo()
    {
        var model = new Zoobesucher();
        var items = await model.GetAllAnimalsOfZooAsync();
        return CreatedAtAction(nameof(GetAllAnimalsOfZoo), items,
            items);
    }

}