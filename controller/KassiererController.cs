using Microsoft.AspNetCore.Mvc;
using ZooAPI.model;

namespace ZooAPI.controller;


[Route("api/[controller]")]
[ApiController]
public class KassiererController : BaseController
{


    
    [HttpPost("TicketKaufen")]
    public async Task<IActionResult> BuyTicket()
    {       
        var model = new Kassierer();
        var item = await model.SellTicket();
        model.Id = 1;
        return CreatedAtAction(nameof(BuyTicket), item,
            new { id = item });
    }

  
    [HttpGet("GetCashierById")]
    public async Task<IActionResult> GetCashierById(int id)
    {
        var model = new Kassierer();
        model = await model.GetById(id);
        return Ok(model);
    }

  
    [HttpGet("GetCashierByName")]
    public async Task<IActionResult> GetCashierByName(string name)
    {
        try
        {
            var model = new Kassierer();  
            model = await model.GetByName(name);
            return Ok(model);
        }
        catch (NullReferenceException)
        {
            return NotFound(name);
        }
        catch(Exception){
            return BadRequest("Error occured");
        }
    }

   
    [HttpGet("GetAllTicket")]
    public async Task<IActionResult> GetAllTickets()
    {   
        var model = new Kassierer();
        var item = await model.GetAllTickets();
        return Ok(new{tickets=item, sum=item.Sum(x => x.Preis)});
    }

   
    [HttpGet("GetAllTicketsOfDate")]
    public async Task<IActionResult> GetAllTicketsOfDate(DateTime date)
    {   
        var model = new Kassierer();
        var item = await model.GetTicketsByDateAsync(date);
        var sum = tickets.Sum(x => x.Preis);
        return Ok(new{tickets,sum});
    }
    



}
