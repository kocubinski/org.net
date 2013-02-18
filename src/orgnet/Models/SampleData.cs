using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace orgnet.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<OrgContext>
    {
        protected override void Seed(OrgContext context)
        {
            var zokuChildren = new List<Node>();
            var zoku = new Task
            {
                Title = "Zoku",
                Children = zokuChildren,
            };

            var networking = new Task
            {
                Title = "Networking",
                Parent = zoku,
            };
            var netChildren = new List<Node> {
                new Task {
                    Title = "RPC Framework",
                    Parent = networking,
                },
                new Task {
                    Title = "Lag compensation",
                    Parent = networking,
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
                    Parent = physics,
                },
                new Task {
                    Title = "Re-write bullet character controller.",
                    Parent = physics,
                }
            };
            physics.Children = physChildren;

            zokuChildren.Add(networking);
            zokuChildren.Add(physics);

            NodeAdder(context, zoku);
        }

        private static void NodeAdder(OrgContext context, Node node)
        {
            if (node is Content) {
                context.Contents.Add((Content)node);
            }
            else if (node is Task) {
                var task = (Task) node;
                var content = Content.CreateFromTask(task);
                task.Content = content;
                context.Tasks.Add(task);
                context.Contents.Add(content);
            }
            else {
                context.Nodes.Add(node);
            }

            if (node.Children == null || !node.Children.Any()) return;
            foreach (var child in node.Children) {
                NodeAdder(context, child);
            }
        }
    }
}