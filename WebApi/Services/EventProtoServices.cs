using Business.Services;
using Grpc.Core;

namespace WebApi.Services;

public class EventProtoServices(EventService eventService, AddressServices addressServices) : EventProto.EventProtoBase
{
    private readonly EventService _eventService = eventService;
    private readonly AddressServices _addressServices = addressServices;


    public override async Task<GetEventResponse> GetEventById(GetEventRequest request, ServerCallContext context)
    {
        var eventEntity = await _eventService.GetEventByIdAsync(request.EventId);
        if(eventEntity == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Event not found"));

        var addressEntity = await _addressServices.GetAddress(eventEntity.Id);

        var eventResponse = new GetEventResponse
        {
            EventId = eventEntity.Id,
            EventName = eventEntity.Name,
            EventDescription = eventEntity.CreateDate.ToString("yyyy-MM-dd"),
            EventDate = eventEntity.EventDate.ToString("yyyy-MM-dd"),
            EventImage = eventEntity.ImageUrl,
            EventAddress = new Address
            {
                Street = addressEntity.Street,
                ZipCode = addressEntity.ZipCode,
                City = addressEntity.City,
                State = addressEntity.State ?? "",
                Country = addressEntity.Country
            },
        };

        return eventResponse;
    }
}
