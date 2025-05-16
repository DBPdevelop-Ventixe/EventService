using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;
public class EventService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
    {
        var entities = await _context.Events
            .Include(s => s.Sponsors)
                .ThenInclude(es => es.Sponsor)
            .Include(p => p.Packages)
                .ThenInclude(ep => ep.Package)
            .ToListAsync();

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
            Status = x.Status,
            CategoryId = x.CategoryId,
            Sponsors = x.Sponsors.Select(x => x.Sponsor).ToList(),
            Packages = x.Packages.Select(x => x.Package).ToList(),
        }).ToList();

        return events ?? [];
    }

    public async Task<EventModel?> GetEventByIdAsync(string id)
    {
        var entity = await _context.Events
            .Include(s => s.Sponsors)
                .ThenInclude(es => es.Sponsor)
            .Include(p => p.Packages)
                .ThenInclude(ep => ep.Package)
            .FirstOrDefaultAsync(x => x.Id == id);

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
