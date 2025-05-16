using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DbContext context) where TEntity : class
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var result = await _dbSet.ToListAsync();
            return result ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null!;
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(string id)
    {
        try
        {
            return await _dbSet.FindAsync(id) ?? null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}
