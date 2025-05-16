using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class EventSponsorEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(Event))]
    public string EventId { get; set; } = null!;
    public EventEntity Event { get; set; } = null!;

    [ForeignKey(nameof(Sponsor))]
    public string SponsorId { get; set; } = null!;
    public SponsorEntity Sponsor { get; set; } = null!;
}
