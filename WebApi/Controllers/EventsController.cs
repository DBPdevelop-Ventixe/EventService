using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventsController(EventService eventService) : ControllerBase
{

    private readonly EventService _eventService = eventService;

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var eventEntity = await _eventService.GetEventByIdAsync(id);
        if (eventEntity == null)
        {
            return NotFound();
        }
        return Ok(eventEntity);
    }
}
