
using Data.Interfaces;

namespace Business.Services;
public class PackageService(IPackageRepository repository)
{
    private readonly IPackageRepository _repository = repository;

    public async Task<bool> SetSoldTickets(string packageId, int ticketsSold)
    {
        var packageEntity = await _repository.GetByIdAsync(packageId);
        if (packageEntity == null)
            return false;

        packageEntity.TicketsSold += ticketsSold;
        return await _repository.Update(packageEntity);
    }
}
