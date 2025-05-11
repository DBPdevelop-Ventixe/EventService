namespace Business.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventModel>> GetAllEventsAsync();
    Task<EventModel?> GetEventByIdAsync(string id);
}