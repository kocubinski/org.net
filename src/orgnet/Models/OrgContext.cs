using System.Data.Entity;

namespace orgnet.Models
{
    public class OrgContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasRequired(t => t.Content);

            modelBuilder.Entity<Node>().HasOptional(n => n.Parent);

            modelBuilder.Entity<Node>()
                .HasMany(n => n.Children)
                .WithOptional(n => n.Parent);
        }
    }
}