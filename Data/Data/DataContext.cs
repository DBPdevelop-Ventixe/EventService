using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<PackageEntity> Packages { get; set; }
    public DbSet<SponsorEntity> Sponsors { get; set; }
    public DbSet<EventPackageEntity> EventPackages { get; set; }
    public DbSet<EventSponsorEntity> EventSponsors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SponsorEntity>()
            .HasData(
                new SponsorEntity
                {
                    Id = "1",
                    Title = "Ipsum 1",
                    LogoUrl = "../images/sponsors/Logo ipsum-1.svg"
                },
                new SponsorEntity
                {
                    Id = "2",
                    Title = "Ipsum 2",
                    LogoUrl = "../images/sponsors/Logo ipsum-2.svg"
                },
                new SponsorEntity
                {
                    Id = "3",
                    Title = "Ipsum 3",
                    LogoUrl = "../images/sponsors/Logo ipsum-3.svg"
                },
                new SponsorEntity
                {
                    Id = "4",
                    Title = "Ipsum 4",
                    LogoUrl = "../images/sponsors/Logo ipsum-4.svg"
                },
                new SponsorEntity
                {
                    Id = "5",
                    Title = "Ipsum 5",
                    LogoUrl = "../images/sponsors/Logo ipsum-5.svg"
                },
                new SponsorEntity
                {
                    Id = "6",
                    Title = "Ipsum 6",
                    LogoUrl = "../images/sponsors/Logo ipsum-6.svg"
                },
                new SponsorEntity
                {
                    Id = "7",
                    Title = "Ipsum 7",
                    LogoUrl = "../images/sponsors/Logo ipsum-7.svg"
                },
                new SponsorEntity
                {
                    Id = "8",
                    Title = "Ipsum 8",
                    LogoUrl = "../images/sponsors/Logo ipsum-8.svg"
                }
            );
        modelBuilder.Entity<PackageEntity>()
            .HasData(
                new PackageEntity
                {
                    Id = "1",
                    Title = "General Package",
                    SeatingBenefits = new[] { "Standing, Access to Festival Grounds" },
                    Price = 35,
                    TicketsAmount = 1000,
                    TicketsSold = 874
                },
                new PackageEntity {
                    Id = "2",
                    Title = "Gold Package",
                    SeatingBenefits = new[] { "Seated, Prime View" },
                    Price = 55,
                    TicketsAmount = 750,
                    TicketsSold = 555
                },
                new PackageEntity
                {
                    Id = "3",
                    Title = "Diamond Package",
                    SeatingBenefits = new[] { "Seated, Front-row View" },
                    Price = 90,
                    TicketsAmount = 300,
                    TicketsSold = 121
                },
                new PackageEntity
                {
                    Id = "4",
                    Title = "VIP Package",
                    SeatingBenefits = new[] { "Seated, Exclusive Lounge" },
                    Price = 175,
                    TicketsAmount = 150,
                    TicketsSold = 34
                },
                new PackageEntity
                {
                    Id = "5",
                    Title = "Ultimate VIP Package",
                    SeatingBenefits = new[] { "Seated, Exclusive Lounge, Meet & Greet, Backstage Access" },
                    Price = 350,
                    TicketsAmount = 75,
                    TicketsSold = 25
                }
            );
        modelBuilder.Entity<EventEntity>()
            .HasData(
            new EventEntity{
                Id = "1",
                Name = "Ginger Festival",
                Description = "The festival takes place in the last full weekend of August, so the next edition will be August 29-31 2025. The most important festival day is Sunday August 31 2025, when we take the famous group photo. Location: A lot of the activities will take place in Spoorpark, Tilburg, which is also where the campsite is located.",
                EventDate = DateTime.Parse("2026-09-01"),
                ImageUrl = "https://img.freepik.com/premium-photo/redhead-days-festival-netherlands_951220-116110.jpg",
                CategoryId = 1,
                Status = "Active",
                CreateDate = DateTime.Parse("2025-01-02"),
                ModifiedDate = DateTime.Parse("2025-03-11"),
            });
        modelBuilder.Entity<EventPackageEntity>()
            .HasData(new EventPackageEntity()
            {
                Id = "1",
                EventId = "1",
                PackageId = "1"
            },
            new EventPackageEntity()
            {
                Id = "2",
                EventId = "1",
                PackageId = "2"
            },
            new EventPackageEntity()
            {
                Id = "3",
                EventId = "1",
                PackageId = "3"
            },
            new EventPackageEntity()
            {
                Id = "4",
                EventId = "1",
                PackageId = "4"
            },
            new EventPackageEntity()
            {
                Id = "5",
                EventId = "1",
                PackageId = "5"
            });
        modelBuilder.Entity<EventSponsorEntity>()
            .HasData(
            new EventSponsorEntity()
            {
                Id = "1",
                EventId = "1",
                SponsorId = "1"
            },
            new EventSponsorEntity()
            {
                Id = "2",
                EventId = "1",
                SponsorId = "2"
            },
            new EventSponsorEntity()
            {
                Id = "3",
                EventId = "1",
                SponsorId = "3"
            },
            new EventSponsorEntity()
            {
                Id = "4",
                EventId = "1",
                SponsorId = "4"
            },
            new EventSponsorEntity()
            {
                Id = "5",
                EventId = "1",
                SponsorId = "5"
            },
            new EventSponsorEntity()
            {
                Id = "6",
                EventId = "1",
                SponsorId = "6"
            },
            new EventSponsorEntity()
            {
                Id = "7",
                EventId = "1",
                SponsorId = "7"
            },
            new EventSponsorEntity()
            {
                Id = "8",
                EventId = "1",
                SponsorId = "8"
            });
    }
}
