using Business.Services;
using Google.Protobuf;
using Grpc.Core;

namespace WebApi.Services;

public class EventProtoServices(EventService eventService, AddressServices addressServices, PackageService packageService) : EventProto.EventProtoBase
{
    private readonly EventService _eventService = eventService;
    private readonly AddressServices _addressServices = addressServices;
    private readonly PackageService _packageService = packageService;

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
            EventTime = eventEntity.EventDate.ToString("HH:mm"),
            EventImage = eventEntity.ImageUrl,
            EventAddress = new Address
            {
                Street = addressEntity.Street,
                ZipCode = addressEntity.ZipCode,
                City = addressEntity.City,
                State = addressEntity.State ?? "",
                Country = addressEntity.Country
            }
        };

        eventResponse.EventPackages.AddRange(eventEntity.Packages.Select(p => new Package
        {
            Id = p.Id,
            Title = p.Title,
            Benefits = { p.SeatingBenefits },
            Price = double.Parse(p.Price.ToString()),
        }));

        return eventResponse;
    }

    public override async Task<SetTicketsSoldResponse> SetTicketsSold(SetTicketsSoldRequest request, ServerCallContext context)
    {
        var result = await _packageService.SetSoldTickets(request.PackageId, request.TicketsSold);
        if (!result)
            throw new RpcException(new Status(StatusCode.NotFound, "Package not found or update failed"));

        return new SetTicketsSoldResponse
        {
            Success = true,
            Message = "Tickets sold updated successfully.",
        };
    }
}
