using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApi.Services;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService, AddressServices addressServices, CategoryService categoryService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;
    private readonly AddressServices _addressServices = addressServices;
    private readonly CategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        foreach (var _event in events)
        {
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
