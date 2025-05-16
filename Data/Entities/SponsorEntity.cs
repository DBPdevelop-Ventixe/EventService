using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class SponsorEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;
    public string? LogoUrl { get; set; }
}