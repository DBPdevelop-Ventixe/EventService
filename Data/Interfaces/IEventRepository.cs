using Data.Entities;

namespace Data.Interfaces;
public interface IEventRepository
{
    Task<IEnumerable<EventEntity>> GetAllAsync();
    Task<EventEntity?> GetByIdAsync(string id);
}