using ZooAPI.Service;

namespace ZooAPI.model;

public class Kassierer : Mitarbeiter
{
    private static KassiererService _service;

    

    public async Task<Kassierer> GetById(int id)
    {
        if (_service == null) _service = new KassiererService();

        return
            await _service.GetKassiererByIdAsync(id);
    }

    public async Task<int> SellTicket()
    {
        var ticket = new Ticket(); // TODO TicketID returnen, zuerst anlegen und dann returnen
        if (_service == null) _service = new KassiererService();

        return await _service.SaveTicket(Id);
    }

    public async Task<Kassierer> GetByName(string name)
    {
        if (_service == null) _service = new KassiererService();

        return
            await _service.GetKassiererByNameAsync(name);
    }

    public async Task<ICollection<Ticket>> GetAllTickets()
    {
        if (_service == null) _service = new KassiererService();
        return await _service.GetAllTickets();
    }

    public async Task<ICollection<Ticket>> GetTicketsByDateAsync(DateTime date){
        if (_service == null) _service = new KassiererService();
        return await _service.GetTicketsByDateAsync(date);
    }

}