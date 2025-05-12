using Business.Interfaces;
using Business.Models;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Business.Services;
public class EventService(DataContext context) : IEventService
{
    private readonly DataContext _context = context;
    HttpClient httpClient = new HttpClient();

    public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
    {
        var entities = await _context.Events.ToListAsync();


        // remapping
        List<EventModel> events = entities.Select(x => new EventModel
        {
            Id = x.Id,
            ImageUrl = x.ImageUrl,
            Name = x.Name,
            CreateDate = x.CreateDate,
            ModifiedDate = x.ModifiedDate,
            EventDate = x.EventDate,
            Description = x.Description,
            Category = x.Category,
            Price = x.Price,
            TicketsAmount = x.TicketsAmount,
            TicketsSold = x.TicketsSold
        }).ToList();

        // Get addresses from api
        foreach (var _event in events)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7193/api/addresses/{_event.Id}");
                if (response.IsSuccessStatusCode)
                    _event.Address = await response.Content.ReadFromJsonAsync<AddressModel>() ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        return events ?? [];
    }

    public async Task<EventModel?> GetEventByIdAsync(string id)
    {
        var entity = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

        EventModel _event = new EventModel
        {
            Id = entity!.Id,
            ImageUrl = entity.ImageUrl,
            Name = entity.Name,
            CreateDate = entity.CreateDate,
            ModifiedDate = entity.ModifiedDate,
            EventDate = entity.EventDate,
            Description = entity.Description,
            Category = entity.Category,
            Price = entity.Price,
            TicketsAmount = entity.TicketsAmount,
            TicketsSold = entity.TicketsSold,
        };

        // Get address from api
        try
        {
            var response = await httpClient.GetAsync($"https://localhost:7193/api/addresses/{id}");
            if (response.IsSuccessStatusCode)
                _event.Address = await response.Content.ReadFromJsonAsync<AddressModel>() ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return _event;
    }
}
