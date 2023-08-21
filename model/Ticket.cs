namespace ZooAPI.model;

public class Ticket
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public DateTime Verkaufsdatum { get; set; }
    public decimal Preis { get; set; }
    public int UserId { get; set; }

   

    public override string ToString()
    {
        
        return $"Id: {Id}, Datum: {Datum}, Verkaufsdatum: {Verkaufsdatum}, Preis: {Preis}, UserId: {UserId}";
    }
}
