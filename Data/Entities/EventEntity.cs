using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class EventEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? ImageUrl { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public DateTime EventDate { get; set; } = DateTime.Now;
    public string Description { get; set; } = null!;


    public int CategoryId { get; set; }

    public int StatusId { get; set; }
    public string Status { get; set; } = null!;


    public decimal Price { get; set; } = 0;
    public int TicketsAmount { get; set; } = 0;
    public int TicketsSold { get; set; } = 0;
}
