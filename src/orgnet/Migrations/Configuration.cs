using System.Collections.Generic;
using orgnet.Models;

namespace orgnet.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OrgContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var zokuChildren = new List<Node>();
            var zoku = new Node
            {
                Title = "Zoku",
                Description = "Zoku: we do stuff real nice.",
                Children = zokuChildren
            };

            var networking = new Node
            {
                Title = "Networking",
                Parent = zoku,
            };
            var netChildren = new List<Node> {
                new Node {
                    Title = "RPC Framework",
                    Description = "Runtime resolution of method calls over networked objects",
                    Parent = networking
                },
                new Node {
                    Title = "Lag compensation",
                    Description = "Compensating for network latency across connected clients.",
                    Parent = networking
                }
            };
            networking.Children = netChildren;

            var physics = new Node
            {
                Title = "Physics",
                Parent = zoku,
            };
            var physChildren = new List<Node> {
                new Node {
                    Title = "Bullet p-Invokes",
                    Parent = physics
                },
                new Node {
                    Title = "Re-write bullet character controller.",
                    Description = "The character controller in bullet sucks.",
                    Parent = physics
                }
            };
            physics.Children = physChildren;

            zokuChildren.Add(networking);
            zokuChildren.Add(physics);

            NodeAdder(context, zoku);
        }

        private static void NodeAdder(OrgContext context, Node node)
        {
            context.Nodes.AddOrUpdate(node);
            if (node.Children == null || !node.Children.Any()) return;
            foreach (var child in node.Children)
            {
                NodeAdder(context, child);
            }
        }
    }
}
