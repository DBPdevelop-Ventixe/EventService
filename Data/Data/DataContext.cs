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
                Description = "Ginger Day: A Celebration of Redheads in the Netherlands\r\n\r\nGinger Day is an extraordinary annual event held in the Netherlands. It is dedicated entirely to people with natural red hair. Known for its joyful spirit and sense of belonging, this event attracts thousands of visitors from around the world. It takes place in the city of Tilburg. Previously it was hosted in Breda. The festival has become a beloved tradition among redheads and redhead enthusiasts alike.\r\n\r\nThe celebration began in 2005. It started as a small artistic project by Dutch painter Bart Rouwenhorst. He was searching for a few redheaded models for his paintings. Instead of a handful of participants, he received over a hundred responses. Surprised by the overwhelming interest, he decided to organize a larger gathering. That spontaneous idea became the first official Ginger Day. Since then, the event has grown significantly. It now welcomes thousands of red-haired visitors each year.\r\n\r\nGinger Day usually takes place in late August or early September. The festival spans an entire weekend. It is free of charge and open to people of all ages. The focus is on community, art, and the unique identity of red-haired individuals. The program includes various activities. There are art exhibitions. There are lectures on genetics and red hair. There are fashion shows. There are pub quizzes. There are musical performances. And there are creative workshops.\r\n\r\nOne of the most iconic moments is the group photo. Hundreds of redheads gather in a public square for a massive photograph. This tradition has become a symbol of unity and pride within the ginger community. It often draws international media attention.\r\n\r\nGinger Day also serves as a platform to challenge stereotypes. It aims to celebrate diversity. It encourages self-confidence among people with red hair. Many participants describe the event as life-changing. It gives them a feeling of acceptance. It gives them a sense of connection. It reminds them they are not alone.\r\n\r\nPeople travel from all over the globe to attend. Visitors come from the United Kingdom. From the United States. From Germany. From Italy. From Australia. And many other countries. The festival has inspired similar events in other parts of the world. But the original Dutch Ginger Day remains the largest and most influential.\r\n\r\nIn summary. Ginger Day in the Netherlands is more than just a festival. It is a tribute to a rare genetic trait. It is a celebration of identity and inclusion. It is a vibrant gathering filled with art. With music. With knowledge. And with shared experiences. It is one of the most colorful and welcoming festivals in Europe. A must-visit for anyone with red hair or a love for unique cultural events.",
                EventDate = DateTime.Parse("2026-08-29"),
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