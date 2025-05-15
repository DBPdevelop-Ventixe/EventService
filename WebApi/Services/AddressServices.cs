using Business.Models;

namespace WebApi.Services;

public class AddressServices(AddressHandler.AddressHandlerClient addressHandler)
{
    private readonly AddressHandler.AddressHandlerClient _addressHandler = addressHandler;

    public async Task<AddressModel> GetAddress(string id)
    {
        // Get address from gRPC service
        try
        {
            var response = await _addressHandler.GetAddressByIdAsync(new GetAddressByIdRequest { Id = id });
            if (response != null)
                return new AddressModel
                {
                    Id = response.Id,
                    Street = response.Street,
                    ZipCode = response.ZipCode,
                    City = response.City,
                    State = response.State,
                    Country = response.Country,
                };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new AddressModel();
    }

}
