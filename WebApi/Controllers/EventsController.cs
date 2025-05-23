using Business.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventsController(EventService eventService, AddressServices addressServices, CategoryService categoryService, IConfiguration configuration) : ControllerBase
{
    private readonly EventService _eventService = eventService;
    private readonly AddressServices _addressServices = addressServices;
    private readonly CategoryService _categoryService = categoryService;
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        foreach (var _event in events)
        {
            _event.TicketsSold = _event.Packages.Sum(x => x.TicketsSold);
            _event.TicketsAmount = _event.Packages.Sum(x => x.TicketsAmount);

            // Get address details using gRPC service
            var address = await _addressServices.GetAddress(_event.Id);
            if (address != null)
                _event.Address = address;

            // Get category details using gRPC service
            var category = await _categoryService.GetCategoryByIdAsync(_event.CategoryId);
            if (category != null)
                _event.Category = category.Description;
        }

        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var eventModel = await _eventService.GetEventByIdAsync(id);
        if (eventModel == null)
            return NotFound();

        eventModel.TicketsSold = eventModel.Packages.Sum(x => x.TicketsSold);
        eventModel.TicketsAmount = eventModel.Packages.Sum(x => x.TicketsAmount);

        // Get address details using gRPC service
        var address = await _addressServices.GetAddress(id);
        if (address != null)
            eventModel.Address = address;

        // Get category details using gRPC service
        var category = await _categoryService.GetCategoryByIdAsync(eventModel.CategoryId);
        if (category != null)
            eventModel.Category = category.Description;

        return Ok(eventModel);
    }
}
