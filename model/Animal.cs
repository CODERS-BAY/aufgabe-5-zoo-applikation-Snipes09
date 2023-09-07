namespace ZooAPI.model;

public class Animal
{
    public int Id { get; set; }
    public string Gattung { get; set; }
    public string Nahrung { get; set; }
    public int GehegeId { get; set; }
    public int MitarbeiterId { get; set; }
    
    public override string ToString()
    {
       
        return
            $"Id: {Id}, Gattung: {Gattung}, Nahrung: {Nahrung}, GehegeId: {GehegeId}, MitarbeiterId: {MitarbeiterId}";
    }

    public async Task<object> GetByAnimalName(string name)
    {
        throw new NotImplementedException("");
    }

    
}