using Business.Models;

public class EventModel
{
    public string Id { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public DateTime EventDate { get; set; } 
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;

    public decimal Price { get; set; } = 0;
    public int TicketsAmount { get; set; } = 0;
    public int TicketsSold { get; set; } = 0;

    public AddressModel Address { get; set; } = new AddressModel();
}
