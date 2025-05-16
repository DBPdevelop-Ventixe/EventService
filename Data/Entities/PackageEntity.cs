using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;
public class PackageEntity
{
    [Key]
    public string Id { get; set; } = new Guid().ToString();
    public string Title { get; set; } = null!;
    public string[]? SeatingBenefits { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int TicketsAmount { get; set; } = 0;
    public int TicketsSold { get; set; } = 0;
}
