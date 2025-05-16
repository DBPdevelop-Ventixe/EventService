using Data.Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;
public class EventService(IEventRepository eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
    {
        var entities = await _eventRepository.GetAllAsync();
        if (entities != null)
        {
            List<EventModel> events = entities.Select(x => new EventModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                CreateDate = x.CreateDate,
                ModifiedDate = x.ModifiedDate,
                EventDate = x.EventDate,
                Description = x.Description,
                Status = x.Status,
                CategoryId = x.CategoryId,
                Sponsors = x.Sponsors.Select(x => x.Sponsor).ToList(),
                Packages = x.Packages.Select(x => x.Package).ToList(),
            }).ToList();

            return events;
        }

        return [];
    }

    public async Task<EventModel?> GetEventByIdAsync(string id)
    {
        var entity = await _eventRepository.GetByIdAsync(id);

        if (entity != null)
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
                Status = entity.Status,
                CategoryId = entity.CategoryId,
                Sponsors = entity.Sponsors.Select(x => x.Sponsor).ToList(),
                Packages = entity.Packages.Select(x => x.Package).ToList(),
            };

            return _event;
        }

        return null!;
    }
}
