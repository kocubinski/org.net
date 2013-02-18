using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace orgnet.Models
{
    public class SampleData : DropCreateDatabaseAlways<OrgContext>
    {
        protected override void Seed(OrgContext context)
        {
            var zokuChildren = new List<Node>();
            var zoku = new Task
            {
                Title = "Zoku",
                //Description = "Zoku: we do stuff real nice.",
                Children = zokuChildren
            };

            var networking = new Task
            {
                Title = "Networking",
                Parent = zoku,
            };
            var netChildren = new List<Node> {
                new Task {
                    Title = "RPC Framework",
                    //Description = "Runtime resolution of method calls over networked objects",
                    Parent = networking
                },
                new Task {
                    Title = "Lag compensation",
                    //Description = "Compensating for network latency across connected clients.",
                    Parent = networking
                }
            };
            networking.Children = netChildren;

            var physics = new Task
            {
                Title = "Physics",
                Parent = zoku,
            };
            var physChildren = new List<Node> {
                new Task {
                    Title = "Bullet p-Invokes",
                    Parent = physics
                },
                new Task {
                    Title = "Re-write bullet character controller.",
                    //Description = "The character controller in bullet sucks.",
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
            if (node is Content)
                context.Contents.Add((Content)node);
            else if (node is Task)
                context.Tasks.Add((Task)node);
            else
                context.Nodes.Add(node);

            if (node.Children == null || !node.Children.Any()) return;
            foreach (var child in node.Children)
            {
                NodeAdder(context, child);
            }
        }
    }
}