using Business.Interfaces;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;
public class EventService(DataContext context) : IEventService
{
    private readonly DataContext _context = context;

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
            Price = x.Price,
            TicketsAmount = x.TicketsAmount,
            TicketsSold = x.TicketsSold,
            Status = x.Status,
            StatusId = x.StatusId,
            CategoryId = x.CategoryId
        }).ToList();

        return events ?? [];
    }

    public async Task<EventModel?> GetEventByIdAsync(string id)
    {
        var entity = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        if(entity != null)
        {
            EventModel _event = new EventModel
            {
                Id = entity!.Id,
                ImageUrl = entity.ImageUrl,
                Name = entity.Name,
                CreateDate = entity.CreateDate,
                ModifiedDate = entity.ModifiedDate,
                EventDate = entity.EventDate,
                Description = entity.Description,
                Price = entity.Price,
                TicketsAmount = entity.TicketsAmount,
                TicketsSold = entity.TicketsSold,
                Status = entity.Status,
                StatusId = entity.StatusId,
                CategoryId = entity.CategoryId
            };

            return _event;
        }

        return null!;
    }
}
