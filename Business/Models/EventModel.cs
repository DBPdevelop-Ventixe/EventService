using Business.Models;
using Data.Entities;

public class EventModel
{
    public string Id { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public DateTime EventDate { get; set; } 
    public string Description { get; set; } = null!;

    public int CategoryId { get; set;  }
    public string Category { get; set; } = null!;
    public int StatusId { get; set; } 
    public string Status { get; set; } = null!;

    public decimal Price { get; set; } = 0;
    public int TicketsAmount { get; set; } = 0;
    public int TicketsSold { get; set; } = 0;


    public AddressModel Address { get; set; } = new AddressModel();
    public ICollection<PackageEntity> Packages { get; set; } = new List<PackageEntity>();
    public ICollection<SponsorEntity> Sponsors { get; set; } = new List<SponsorEntity>();
}
