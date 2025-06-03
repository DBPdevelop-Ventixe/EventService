using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;
public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
    public override async Task<IEnumerable<EventEntity>> GetAllAsync()
    {
        try
        {
            Console.WriteLine($"Requesting all events data");
            var result = await _dbSet
            .Include(s => s.Sponsors)
                .ThenInclude(es => es.Sponsor)
            .Include(p => p.Packages)
                .ThenInclude(ep => ep.Package)
            .AsSplitQuery()
            .ToListAsync() ?? [];


            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null!;
        }
    }

    public override async Task<EventEntity?> GetByIdAsync(string id)
    {
        Console.WriteLine($"Requesting data for event: {id}");
        try
        {
            var result = await _dbSet
            .Include(s => s.Sponsors)
                .ThenInclude(es => es.Sponsor)
            .Include(p => p.Packages)
                .ThenInclude(ep => ep.Package)
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}
