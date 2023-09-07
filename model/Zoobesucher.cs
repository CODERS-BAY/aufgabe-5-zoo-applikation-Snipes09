using ZooAPI.Service;

namespace ZooAPI.model;

public class Zoobesucher
{
    private static ZoobesucherService _service;

    public int Id { get; set; }
    public Ticket Ticket { get; set; }




    public async Task<Animal> GetAnimalByAnimalName(string name)
    {
        if (_service == null) _service = new ZoobesucherService();
        return await _service.GetAnimalByNameAsync(name);
    }


    public async Task<ICollection<Animal>> GetAllAnimalsOfZooAsync()
    {
        if (_service == null) _service = new ZoobesucherService();
        return await _service.GetAllAnimalsOfZooAsync();
    }
}



