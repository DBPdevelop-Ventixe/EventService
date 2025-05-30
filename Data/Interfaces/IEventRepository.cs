using Data.Entities;

namespace Data.Interfaces;
public interface IEventRepository : IBaseRepository<EventEntity>
{
    new Task<IEnumerable<EventEntity>> GetAllAsync();
    new Task<EventEntity?> GetByIdAsync(string id);
}