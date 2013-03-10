using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class OrgContext : DbContext
{
    public DbSet<Card> Cards { get; set; }

    public DbSet<Content> Contents { get; set; }

    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Content>().HasRequired(content => content.Parent);

        modelBuilder.Entity<Card>().HasOptional(card => card.Parent);

        modelBuilder.Entity<Card>()
            .HasMany(card => card.Children)
            .WithOptional(card => card.Parent);

        modelBuilder.Entity<Card>()
            .HasMany(card => card.Contents)
            .WithRequired(content => content.Parent);
    }
}

public class SampleData : DropCreateDatabaseIfModelChanges<OrgContext>
{
    protected override void Seed(OrgContext context)
    {
        var zokuChildren = new List<Card>();
        var zoku = new Card
        {
            Title = "Zoku",
            Children = zokuChildren,
        };

        var networking = new Card
        {
            Title = "Networking",
            Parent = zoku,
        };
        var netChildren = new List<Card> {
                new Card {
                    Title = "RPC Framework",
                    Parent = networking,
                },
                new Card {
                    Title = "Lag compensation",
                    Parent = networking,
                }
            };
        networking.Children = netChildren;

        var physics = new Card
        {
            Title = "Physics",
            Parent = zoku,
        };
        var physChildren = new List<Card> {
                new Card {
                    Title = "Bullet p-Invokes",
                    Parent = physics,
                },
                new Card {
                    Title = "Re-write bullet character controller.",
                    Parent = physics,
                }
            };
        physics.Children = physChildren;

        zokuChildren.Add(networking);
        zokuChildren.Add(physics);

        NodeAdder(context, zoku);
    }

    private static void NodeAdder(OrgContext context, Card card)
    {
        context.Cards.Add(card);
        if (card.Children == null || !card.Children.Any()) return;

        foreach (var child in card.Children)
            NodeAdder(context, child);
    }
}