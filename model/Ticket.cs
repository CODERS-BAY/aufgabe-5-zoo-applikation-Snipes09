namespace ZooAPI.model;

public class Ticket : IComparable<Ticket>
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public DateTime Verkaufsdatum { get; set; }
    public decimal Preis { get; set; }
    public int UserId { get; set; }

    public int CompareTo(Ticket? other)
    {
        if (other == null) return 1;

        return Datum.CompareTo(other.Datum);
    }

    public override bool Equals(object? obj)
    {
        
        if (obj == null || GetType() != obj.GetType()) return false;

        var other = obj as Ticket;
        return Id == other?.Id;
    }

    public override string ToString()
    {
        
        return $"Id: {Id}, Datum: {Datum}, Verkaufsdatum: {Verkaufsdatum}, Preis: {Preis}, UserId: {UserId}";
    }
}